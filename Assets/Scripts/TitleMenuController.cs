using UnityEngine;

public class TitleMenuController : MonoBehaviour
{
    public void SelectListener()
    {
        if (RoleModeManager.instance != null)
            RoleModeManager.instance.SetListenerMode();
    }

    public void SelectPerformer()
    {
        if (RoleModeManager.instance != null)
            RoleModeManager.instance.SetPerformerMode();
    }

    public void EnterExperience()
    {
        if (RoleModeManager.instance != null)
            RoleModeManager.instance.EnterExperience();
    }
}