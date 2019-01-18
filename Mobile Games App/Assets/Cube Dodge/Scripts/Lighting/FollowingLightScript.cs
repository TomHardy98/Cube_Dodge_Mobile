/// FollowingLightScript.cs
/// Controls the light following the target

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Identical to the following camera script, illuminates near player

public class FollowingLightScript : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 8.0f;   // Set the smoothSpeed to 8

    void LateUpdate()
    {
        Vector3 lightPosition = target.position + offset;   // Set the light position to the target position + offset

        Vector3 smoothedPosition = Vector3.Lerp( transform.position, lightPosition, smoothSpeed * Time.deltaTime );   // Set the smoothed position to a lerp between the object and light

        transform.position = smoothedPosition;   // Set the new position to the smoothed position
    }
}