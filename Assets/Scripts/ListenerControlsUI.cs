using UnityEngine;
using TMPro;

public class ListenerControlsUI : MonoBehaviour
{
    public TextMeshProUGUI listenerLabel;

    void Update()
    {
        if (listenerLabel == null)
            return;

        if (TitleMenuState.menuOpen || RoleModeManager.currentMode != RoleModeManager.RoleMode.Listener)
        {
            listenerLabel.text = "";
            return;
        }

        listenerLabel.text =
            "AUDIENCE MODE\n\n" +
            "O = switch to Audience Mode\n" +
            "P = switch to Performer Mode\n" +
            "K = show or hide the stage keyboard\n\n" +
            "LISTENING TIPS\n" +
            "Walk closer to the stage to hear the music louder and more directly.\n" +
            "Move farther back to hear more of the room and atmosphere.\n\n" +
            "SOUND MODES\n" +
            "1 = close and focused\n" +
            "2 = balanced hall sound\n" +
            "3 = wider and more spacious\n" +
            "4 = most atmospheric\n\n" +
            "Try pressing 1 + 2 + 3 + 4 together for a very clear, immersive sound.";
    }
}