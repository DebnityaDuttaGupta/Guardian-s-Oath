using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLeftandRight : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float normalSpeed = 2f;

    public GameObject triggerObject;

    private bool movingToA = true; // Start by moving towards point A

    private void Start()
    {
        gameObject.SetActive(false);
    }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == triggerObject)
        {
            gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == triggerObject)
        {
            gameObject.SetActive(false);
        }
    }
}
