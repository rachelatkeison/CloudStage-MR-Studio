using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 4.5f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (TitleMenuState.menuOpen)
            return;

        if (PianoFocusState.pianoFocused)
            return;

        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W))
            moveZ += 1f;
        if (Input.GetKey(KeyCode.S))
            moveZ -= 1f;
        if (Input.GetKey(KeyCode.A))
            moveX -= 1f;
        if (Input.GetKey(KeyCode.D))
            moveX += 1f;

        Vector3 move = (transform.right * moveX + transform.forward * moveZ).normalized;
        controller.Move(move * moveSpeed * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0f)
            velocity.y = -2f;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}