using UnityEngine;

public class FloatingHover : MonoBehaviour
{
    public float hoverAmplitude = 0.25f;
    public float hoverSpeed = 1.2f;

    public float swayAngle = 10f;
    public float swaySpeed = 0.6f;

    private Vector3 startPosition;
    private Quaternion startRotation;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        // vertical hover
        float hoverOffset = Mathf.Sin(Time.time * hoverSpeed) * hoverAmplitude;

        transform.position = new Vector3(
            startPosition.x,
            startPosition.y + hoverOffset,
            startPosition.z
        );

        // gentle side-to-side sway
        float swayY = Mathf.Sin(Time.time * swaySpeed) * swayAngle;
        float swayX = Mathf.Sin(Time.time * swaySpeed * 0.7f) * 3f;

        transform.rotation = startRotation * Quaternion.Euler(swayX, swayY, 0);
    }
}