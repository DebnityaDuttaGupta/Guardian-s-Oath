using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    public Transform target; // The target the camera will follow
    public float smoothSpeed = 0.125f; // The smoothness of the camera follow

    void LateUpdate()
    {
        if (target != null)
        {
            // Set the desired position and rotation values
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y + 5f, -10f);
            Quaternion desiredRotation = Quaternion.Euler(10f, 0f, 0f);

            // Smoothly interpolate to the desired position and rotation
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
        }
        else
        {
            Debug.LogWarning("CameraFollow: Target not assigned.");
        }
    }
}
