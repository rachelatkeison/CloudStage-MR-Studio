using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 180f;
    public Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        UnlockCursor();
    }

    void Update()
    {
        if (TitleMenuState.menuOpen)
        {
            UnlockCursor();
            return;
        }

        if (PianoFocusState.pianoFocused)
        {
            UnlockCursor();
            return;
        }

        LockCursor();

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}