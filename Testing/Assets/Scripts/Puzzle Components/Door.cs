using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform pointB;
    public GameObject objectToMove;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MoveObjectToPointB();
        }
    }

    private void MoveObjectToPointB()
    {
        if (objectToMove != null)
        {
            objectToMove.transform.position = pointB.position;
        }
        else
        {
            Debug.LogError("GameObject to move not assigned!");
        }
    }
}
