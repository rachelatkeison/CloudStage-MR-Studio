using UnityEngine;
using TMPro;

public class ModeLabelUI : MonoBehaviour
{
    public TextMeshProUGUI modeLabel;

    void Update()
    {
        if (modeLabel == null)
            return;

        string roleName = RoleModeManager.currentMode.ToString().ToUpper();
        modeLabel.text = "ROLE: " + roleName;
    }
}