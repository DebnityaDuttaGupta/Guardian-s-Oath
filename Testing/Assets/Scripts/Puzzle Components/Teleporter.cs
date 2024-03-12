using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform pointB;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayer(other);
        }
    }

    private void TeleportPlayer(Collider playercol)
    {
        playercol.transform.position = pointB.position;
    }
}
