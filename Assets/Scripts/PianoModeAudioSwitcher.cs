using UnityEngine;

public class PianoModeAudioSwitcher : MonoBehaviour
{
    public AudioSource stageAmbienceSource;

    private bool previousPianoFocusState = false;

    void Update()
    {
        bool pianoFocused = PianoFocusState.pianoFocused;

        if (pianoFocused != previousPianoFocusState)
        {
            if (stageAmbienceSource != null)
            {
                if (pianoFocused)
                {
                    stageAmbienceSource.Stop();
                }
                else
                {
                    if (!stageAmbienceSource.isPlaying)
                    {
                        stageAmbienceSource.Play();
                    }
                }
            }

            previousPianoFocusState = pianoFocused;
        }
    }
}