/// CameraFollower.cs
/// Controls the camera following the targets position

using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 8.0f;   // Set the smoothSpeed to 8
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 cameraPosition = target.position + offset;   // Set the camera position to the target position + offset
        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, cameraPosition, smoothSpeed * Time.deltaTime);   // Set the smoothed position to a lerp between the object and camera

        transform.position = smoothedPosition;   // Set the new position to the smoothed position
    }
}