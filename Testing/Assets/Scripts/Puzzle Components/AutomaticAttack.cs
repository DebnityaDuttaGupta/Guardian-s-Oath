using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticAttack : MonoBehaviour
{
    public GameObject prefabToFire;
    public Transform firePoint;
    public float fireDelay = 5f;
    public float destroyDelay = 6f;

    private void Start()
    {
        // Start firing sequence
        InvokeRepeating("FirePrefab", 0f, fireDelay);
    }

    private void FirePrefab()
    {
        // Instantiate the prefab at the firePoint position and rotation
        GameObject bullet = Instantiate(prefabToFire, firePoint.position, firePoint.rotation);

        // Destroy the prefab after a certain delay
        Destroy(bullet, destroyDelay);
    }
}
