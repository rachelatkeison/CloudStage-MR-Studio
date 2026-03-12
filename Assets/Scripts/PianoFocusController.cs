using UnityEngine;

public class PianoFocusController : MonoBehaviour
{
    public GameObject pianoKeyLabels;

    void Update()
    {
        if (TitleMenuState.menuOpen)
            return;

        if (RoleModeManager.currentMode != RoleModeManager.RoleMode.Performer)
        {
            PianoFocusState.pianoFocused = false;
			PianoKeyDisplayState.Clear();

            if (pianoKeyLabels != null)
                pianoKeyLabels.SetActive(false);

            return;
        }

        if (Input.GetKeyDown(KeyCode.I)) {
    		PianoFocusState.pianoFocused = !PianoFocusState.pianoFocused;

    		if (!PianoFocusState.pianoFocused)
        		PianoKeyDisplayState.Clear();

    		if (pianoKeyLabels != null)
        		pianoKeyLabels.SetActive(PianoFocusState.pianoFocused);
		}
    }
}