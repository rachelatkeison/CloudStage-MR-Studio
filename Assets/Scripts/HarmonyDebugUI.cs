using UnityEngine;
using TMPro;

public class HarmonyDebugUI : MonoBehaviour
{
    public TextMeshProUGUI label;

    string[] noteNames =
    {
        "C","C#","D","Eb","E","F",
        "F#","G","Ab","A","Bb","B"
    };

    void Update()
    {
        if (label == null)
            return;

        if (TitleMenuState.menuOpen)
        {
            label.text = "";
            return;
        }

        if (HarmonyAnalyzer.detectedRoot < 0)
        {
            label.text = "Chord: ---";
            return;
        }

        string name = noteNames[HarmonyAnalyzer.detectedRoot];
        string quality = HarmonyAnalyzer.detectedMinor ? "Minor" : "Major";

        label.text = "Chord: " + name + " " + quality;
    }
}