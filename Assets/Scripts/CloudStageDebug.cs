using UnityEngine;
using TMPro;

public class CloudStageDebug : MonoBehaviour
{
    public TextMeshProUGUI debugText;
    public Transform player;
    public Transform stage;
    public MusicAnalyzer musicState;

    void Update()
    {
        if (debugText == null)
            return;

        if (TitleMenuState.menuOpen)
        {
            debugText.text = "";
            return;
        }

        float distance = 0f;
        if (player != null && stage != null)
            distance = Vector3.Distance(player.position, stage.position);

        string role = RoleModeManager.currentMode.ToString();
        int activeNotes = musicState != null ? musicState.activeNotes : 0;
        float intensity = musicState != null ? musicState.intensity : 0f;

        debugText.text =
            "CLOUDSTAGE DEBUG\n\n" +
            "Role: " + role + "\n" +
            "Distance to Stage: " + distance.ToString("F1") + "\n" +
            "Active Notes: " + activeNotes + "\n" +
            "Intensity: " + intensity.ToString("F2");
    }
}