using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ListenerSoundModeController : MonoBehaviour
{
    public enum ListenerSoundMode
    {
        CloseListening,
        BalancedHall,
        WideSpatial,
        Atmospheric
    }

    public static ListenerSoundMode currentMode = ListenerSoundMode.BalancedHall;

    public AudioSource ambienceSource;
    public AudioLowPassFilter lowPassFilter;
    public AudioReverbFilter reverbFilter;

    public float transitionSpeed = 3f;

    private float targetVolume;
    private float targetCutoff;
    private float targetSpread;

    void Start()
    {
        if (ambienceSource == null)
            ambienceSource = GetComponent<AudioSource>();

        if (lowPassFilter == null)
            lowPassFilter = GetComponent<AudioLowPassFilter>();

        if (reverbFilter == null)
            reverbFilter = GetComponent<AudioReverbFilter>();

        ApplyModeInstant(currentMode);
    }

    void Update()
    {
        if (TitleMenuState.menuOpen)
            return;

        if (RoleModeManager.currentMode != RoleModeManager.RoleMode.Listener)
            return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
            SetMode(ListenerSoundMode.CloseListening);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            SetMode(ListenerSoundMode.BalancedHall);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            SetMode(ListenerSoundMode.WideSpatial);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            SetMode(ListenerSoundMode.Atmospheric);

        SmoothApply();
    }

    public void SetMode(ListenerSoundMode newMode)
    {
        currentMode = newMode;

        switch (currentMode)
        {
            case ListenerSoundMode.CloseListening:
                targetVolume = 1.0f;
                targetCutoff = 18000f;
                targetSpread = 10f;
                if (reverbFilter != null)
                    reverbFilter.reverbPreset = AudioReverbPreset.Off;
                break;

            case ListenerSoundMode.BalancedHall:
                targetVolume = 1.0f;
                targetCutoff = 12000f;
                targetSpread = 60f;
                if (reverbFilter != null)
                    reverbFilter.reverbPreset = AudioReverbPreset.Auditorium;
                break;

            case ListenerSoundMode.WideSpatial:
                targetVolume = 0.95f;
                targetCutoff = 9000f;
                targetSpread = 180f;
                if (reverbFilter != null)
                    reverbFilter.reverbPreset = AudioReverbPreset.Arena;
                break;

            case ListenerSoundMode.Atmospheric:
                targetVolume = 0.9f;
                targetCutoff = 3500f;
                targetSpread = 260f;
                if (reverbFilter != null)
                    reverbFilter.reverbPreset = AudioReverbPreset.Cave;
                break;
        }
    }

    void ApplyModeInstant(ListenerSoundMode mode)
    {
        SetMode(mode);

        if (ambienceSource != null)
        {
            ambienceSource.volume = targetVolume;
            ambienceSource.spread = targetSpread;
        }

        if (lowPassFilter != null)
        {
            lowPassFilter.cutoffFrequency = targetCutoff;
        }
    }

    void SmoothApply()
    {
        if (ambienceSource != null)
        {
            ambienceSource.volume = Mathf.Lerp(
                ambienceSource.volume,
                targetVolume,
                Time.deltaTime * transitionSpeed
            );

            ambienceSource.spread = Mathf.Lerp(
                ambienceSource.spread,
                targetSpread,
                Time.deltaTime * transitionSpeed
            );
        }

        if (lowPassFilter != null)
        {
            lowPassFilter.cutoffFrequency = Mathf.Lerp(
                lowPassFilter.cutoffFrequency,
                targetCutoff,
                Time.deltaTime * transitionSpeed
            );
        }
    }

    public static string GetModeName()
    {
        switch (currentMode)
        {
            case ListenerSoundMode.CloseListening:
                return "Close Listening";
            case ListenerSoundMode.BalancedHall:
                return "Balanced Hall";
            case ListenerSoundMode.WideSpatial:
                return "Wide Spatial";
            case ListenerSoundMode.Atmospheric:
                return "Atmospheric";
            default:
                return "Balanced Hall";
        }
    }
}