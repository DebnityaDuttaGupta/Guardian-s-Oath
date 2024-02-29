using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public FallingTrap fallingTrap;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fallingTrap.ActivateTrap();
        }
    }
}
