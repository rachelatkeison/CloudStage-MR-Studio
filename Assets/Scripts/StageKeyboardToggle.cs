using UnityEngine;

public class StageKeyboardToggle : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.K;

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}