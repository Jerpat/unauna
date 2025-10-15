using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0, 0, -10);

    void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        if (target == null) return;
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
