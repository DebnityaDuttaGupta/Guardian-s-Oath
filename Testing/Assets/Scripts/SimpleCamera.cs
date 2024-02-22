using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // The target the camera will follow
    public Vector3 offset = new Vector3(0f, 2f, -5f); // The offset from the target

    public float smoothSpeed = 0.125f; // The smoothness of the camera follow
    [SerializeField] public float additionalHeight = 2f;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

            // Lift the camera without affecting rotation or offset
            smoothedPosition.y += additionalHeight;

            transform.position = smoothedPosition;
            transform.LookAt(target.position);
        }
        else
        {
            Debug.LogWarning("CameraFollow: Target not assigned.");
        }
    }
}
