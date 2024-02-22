using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAutomatic : MonoBehaviour
{
    public Transform firepoint;
    public GameObject homingProjectilePrefab;
    public float AppearTime;
    void Start()
    {
        InvokeRepeating("Shoot", AppearTime, 3f);
    }

    private void Shoot()
    {
        Instantiate(homingProjectilePrefab, firepoint.position, firepoint.rotation);
    }
}
