using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;
    public float yOffset = 2f;
    public LayerMask collisionMask; 
    public float minDistance = 0.5f; 

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        Vector3 direction = targetPosition - target.position;
        float distance = direction.magnitude;

        RaycastHit hit;

        if (Physics.Raycast(target.position, direction.normalized, out hit, distance, collisionMask))
        {
            Vector3 hitPosition = hit.point - direction.normalized * minDistance;
            transform.position = Vector3.Slerp(transform.position, hitPosition, FollowSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Slerp(transform.position, targetPosition, FollowSpeed * Time.deltaTime);
        }
    }
}
