using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HarmonyPadSynth : MonoBehaviour
{
    public float padVolume = 0.04f;

    float phase;
    float frequency;

    int sampleRate;

    void Start()
    {
        sampleRate = AudioSettings.outputSampleRate;
    }

    void Update()
    {
        if (HarmonyAnalyzer.detectedRoot < 0)
            return;

        int midi = HarmonyAnalyzer.detectedRoot + 48;

        frequency = 440f * Mathf.Pow(2f, (midi - 69) / 12f);
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        for (int i = 0; i < data.Length; i += channels)
        {
            float sample = Mathf.Sin(phase) * padVolume;

            phase += 2f * Mathf.PI * frequency / sampleRate;

            if (phase > Mathf.PI * 2)
                phase -= Mathf.PI * 2;

            for (int c = 0; c < channels; c++)
                data[i + c] += sample;
        }
    }
}