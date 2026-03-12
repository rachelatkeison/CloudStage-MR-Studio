using UnityEngine;
using TMPro;

public class PianoKeyPressUI : MonoBehaviour
{
    public TextMeshProUGUI keyPressLabel;

    private readonly string[] noteNames =
    {
        "C", "C#", "D", "Eb", "E", "F",
        "F#", "G", "Ab", "A", "Bb", "B"
    };

    void Update()
    {
        if (keyPressLabel == null)
            return;

        if (TitleMenuState.menuOpen)
        {
            keyPressLabel.text = "";
            return;
        }

        if (RoleModeManager.currentMode != RoleModeManager.RoleMode.Performer)
        {
            keyPressLabel.text = "";
            return;
        }

        if (!PianoFocusState.pianoFocused)
        {
            keyPressLabel.text = "";
            return;
        }

        if (HarmonyAnalyzer.detectedRoot >= 0)
        {
            string chordName = noteNames[HarmonyAnalyzer.detectedRoot];

            if (HarmonyAnalyzer.detectedMinor)
                chordName += " Minor";
            else
                chordName += " Major";

            keyPressLabel.text = "Current Input: " + chordName;
        }
        else
        {
            keyPressLabel.text = "Current Input: " + PianoKeyDisplayState.GetDisplayText();
        }
    }
}