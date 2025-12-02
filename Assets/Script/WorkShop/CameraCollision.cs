using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform cameraPivot;   
    public Transform cameraTransform; 
    public float defaultDistance = 3f;
    public float minDistance = 0.5f;
    public float smooth = 10f;
    public LayerMask collisionMask;

    private float currentDistance;

    void Start()
    {
        currentDistance = defaultDistance;
    }

    void LateUpdate()
    {
        Vector3 dir = (cameraTransform.position - cameraPivot.position).normalized;

        Vector3 desiredPos = cameraPivot.position + dir * defaultDistance;

        RaycastHit hit;
        float targetDistance = defaultDistance;

        if (Physics.Linecast(cameraPivot.position, desiredPos, out hit, collisionMask))
        {
            targetDistance = Mathf.Clamp(hit.distance, minDistance, defaultDistance);
        }

        currentDistance = Mathf.Lerp(currentDistance, targetDistance, Time.deltaTime * smooth);

        cameraTransform.position = cameraPivot.position + dir * currentDistance;
    }
}
