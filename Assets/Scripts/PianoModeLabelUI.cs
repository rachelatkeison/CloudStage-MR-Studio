using UnityEngine;
using TMPro;

public class PianoModeLabelUI : MonoBehaviour
{
    public TextMeshProUGUI pianoModeLabel;

    void Update()
    {
        if (pianoModeLabel == null)
            return;

        if (TitleMenuState.menuOpen || RoleModeManager.currentMode != RoleModeManager.RoleMode.Performer)
        {
            pianoModeLabel.text = "";
            return;
        }

        if (PianoFocusState.pianoFocused)
        {
            pianoModeLabel.text =
                "PIANO MODE\n\n" +
                "I = exit piano mode\n\n" +
                "The stage keyboard is active.\n" +
                "Movement is paused so you can play without walking.\n\n";
        }
        else
        {
            pianoModeLabel.text =
                "PERFORMER MODE\n\n" +
                "O = switch to Audience Mode\n" +
                "P = switch to Performer Mode\n" +
                "K = show or hide the stage keyboard\n" +
                "I = enter piano mode\n\n" +
                "In Performer Mode, you can go on stage and play the instrument.";
        }
    }
}