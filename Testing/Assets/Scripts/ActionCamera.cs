using UnityEngine;

public class ActionCamera : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 5f;

    private Transform targetPoint;

    private void Start()
    {
        targetPoint = pointA;
    }

    private void Update()
    {
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);

        if (transform.position == targetPoint.position)
        {
            // Check if the object has reached the end point before switching to the next target
            if (targetPoint == pointA)
            {
                targetPoint = pointB;
            }
            
        }
    }
}
