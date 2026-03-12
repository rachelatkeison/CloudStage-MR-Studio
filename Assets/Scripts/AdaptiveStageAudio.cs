using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AdaptiveStageAudio : MonoBehaviour
{
    public MusicAnalyzer musicState;

    private AudioSource audioSource;
    private AudioLowPassFilter lowpass;

    public float minVolume = 0.75f;
    public float maxVolume = 1.0f;

    public float minLowpass = 4500f;
    public float maxLowpass = 22000f;

    public float minPitch = 0.98f;
    public float maxPitch = 1.03f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        lowpass = GetComponent<AudioLowPassFilter>();
        if (lowpass == null)
            lowpass = gameObject.AddComponent<AudioLowPassFilter>();
    }

    void Update()
    {
        if (musicState == null)
            return;

        float intensity = musicState.intensity;

        if (CloudStageZoneTracker.currentMode == "Ambient")
        {
            intensity *= 0.8f;
        }
        else if (CloudStageZoneTracker.currentMode == "Performer")
        {
            intensity *= 1.15f;
        }

        intensity = Mathf.Clamp01(intensity);

        audioSource.volume = Mathf.Lerp(minVolume, maxVolume, intensity);
        audioSource.pitch = Mathf.Lerp(minPitch, maxPitch, intensity);

        if (lowpass != null)
        {
            lowpass.cutoffFrequency = Mathf.Lerp(minLowpass, maxLowpass, intensity);
            lowpass.lowpassResonanceQ = 1.1f;
        }
    }
}