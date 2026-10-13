using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0f, 10f, 0);
    [SerializeField] private float followSpeed = 8f;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Vector target position that will use target's position and also added by offset
        Vector3 targetPosition = target.position + offset;

        // Transform the camera to the target position with it's smooth following speed
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
