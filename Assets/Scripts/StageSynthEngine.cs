using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class StageSynthEngine : MonoBehaviour
{
    public float masterVolume = 0.08f;

    [Header("Envelope")]
    public float attackTime = 0.02f;
    public float releaseTime = 0.25f;

    [Header("Tone")]
    [Range(0f, 1f)] public float sineMix = 0.75f;
    [Range(0f, 1f)] public float sawMix = 0.25f;
    
    [Header("Filter")]
    [Range(200f, 20000f)]
    public float cutoffFrequency = 6000f;

    private float filterBuffer = 0f;

    private class SynthVoice
    {
        public int midiNote;
        public float frequency;
        public float phase;
        public float targetAmplitude;
        public float currentAmplitude;
        public bool isReleasing;
    }

    private readonly List<SynthVoice> activeVoices = new List<SynthVoice>();
    private readonly object voiceLock = new object();
    private int sampleRate;

    void Start()
    {
        sampleRate = AudioSettings.outputSampleRate;

        var audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = true;
        audioSource.loop = true;
        audioSource.spatialBlend = 0f;
    }

    public void NoteOn(int midiNote, float velocity = 1.0f)
    {
        float frequency = MidiNoteToFrequency(midiNote);

        lock (voiceLock)
        {
            for (int i = 0; i < activeVoices.Count; i++)
            {
                if (activeVoices[i].midiNote == midiNote)
                {
                    activeVoices[i].targetAmplitude = Mathf.Clamp01(velocity);
                    activeVoices[i].isReleasing = false;
                    return;
                }
            }

            activeVoices.Add(new SynthVoice
            {
                midiNote = midiNote,
                frequency = frequency,
                phase = 0f,
                targetAmplitude = Mathf.Clamp01(velocity),
                currentAmplitude = 0f,
                isReleasing = false
            });
        }
    }

    public void NoteOff(int midiNote)
    {
        lock (voiceLock)
        {
            for (int i = 0; i < activeVoices.Count; i++)
            {
                if (activeVoices[i].midiNote == midiNote)
                    activeVoices[i].isReleasing = true;
            }
        }
    }

    float MidiNoteToFrequency(int midiNote)
    {
        return 440f * Mathf.Pow(2f, (midiNote - 69) / 12f);
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        float attackStep = attackTime > 0f ? 1f / (attackTime * sampleRate) : 1f;
        float releaseStep = releaseTime > 0f ? 1f / (releaseTime * sampleRate) : 1f;

        lock (voiceLock)
        {
            for (int i = 0; i < data.Length; i += channels)
            {
                float sample = 0f;

                for (int v = activeVoices.Count - 1; v >= 0; v--)
                {
                    SynthVoice voice = activeVoices[v];

                    if (!voice.isReleasing)
                        voice.currentAmplitude = Mathf.MoveTowards(voice.currentAmplitude, voice.targetAmplitude, attackStep);
                    else
                        voice.currentAmplitude = Mathf.MoveTowards(voice.currentAmplitude, 0f, releaseStep);

                    float voiceSample = Mathf.Sin(voice.phase);

                    sample += voiceSample * voice.currentAmplitude;

                    voice.phase += 2f * Mathf.PI * voice.frequency / sampleRate;
                    if (voice.phase > 2f * Mathf.PI)
                        voice.phase -= 2f * Mathf.PI;

                    if (voice.isReleasing && voice.currentAmplitude <= 0.0005f)
                        activeVoices.RemoveAt(v);
                }

                sample *= masterVolume;
                
                float rc = 1.0f / (cutoffFrequency * 2f * Mathf.PI);
                float dt = 1.0f / sampleRate;
                float alpha = dt / (rc + dt);

                filterBuffer = filterBuffer + alpha * (sample - filterBuffer);
                sample = filterBuffer;

                for (int c = 0; c < channels; c++)
                    data[i + c] = sample;
            }
        }
    }
}