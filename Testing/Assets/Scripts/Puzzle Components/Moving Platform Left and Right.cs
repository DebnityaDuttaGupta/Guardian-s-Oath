using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLeftandRight : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float normalSpeed = 2f;

    private bool movingToA = true; // Start by moving towards point A

    private void Update()
    {
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        float step = normalSpeed * Time.deltaTime;
        Transform targetTransform = movingToA ? pointA : pointB;

        transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, step);

        float distanceToTarget = Vector3.Distance(transform.position, targetTransform.position);

        if (distanceToTarget < 0.01f)
        {
            // Change direction when reaching the target position
            movingToA = !movingToA;
        }
    }
}
