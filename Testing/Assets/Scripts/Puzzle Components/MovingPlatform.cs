using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float normalSpeed = 2f;
    public float decelerationDistance = 1f;

    private bool movingToA = false;
    public float currentSpeed;

    private void Start()
    {
        currentSpeed = normalSpeed;
    }

    private void Update()
    {
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        float step = currentSpeed * Time.deltaTime;
        Transform targetTransform = movingToA ? pointA : pointB;

        transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, step);

        float distanceToTarget = Vector3.Distance(transform.position, targetTransform.position);

        if (distanceToTarget < decelerationDistance)
        {
            // Gradually decrease speed as it approaches point A or B
            float decelerationRate = Mathf.SmoothStep(1f, 0f, distanceToTarget / decelerationDistance);
            currentSpeed = Mathf.Lerp(currentSpeed, 0f, Time.deltaTime * decelerationRate);
        }
        else
        {
            // Reset speed when not close to points A or B
            currentSpeed = normalSpeed;
        }

        if (distanceToTarget < 0.01f)
        {
            // Change direction when reaching the target position
            movingToA = !movingToA;
        }
    }

    public Vector3 GetPlatformMovement()
    {
        float pingPongValue = Mathf.PingPong(Time.time * normalSpeed, 1.0f);
        return Vector3.Lerp(pointA.position, pointB.position, pingPongValue) - transform.position;
    }
}
