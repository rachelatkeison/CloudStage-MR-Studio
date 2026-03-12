using UnityEngine;

public class RoleModeHotKeys : MonoBehaviour
{
    void Update()
    {
        if (TitleMenuState.menuOpen)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (RoleModeManager.instance != null)
                    RoleModeManager.instance.EnterExperience();
            }

            return;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            if (RoleModeManager.instance != null)
                RoleModeManager.instance.SetListenerMode();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (RoleModeManager.instance != null)
                RoleModeManager.instance.SetPerformerMode();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (RoleModeManager.instance != null)
                RoleModeManager.instance.ToggleKeyboardVisibilityPreference();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (RoleModeManager.instance != null)
                RoleModeManager.instance.TeleportToCurrentRole();
        }
    }
}