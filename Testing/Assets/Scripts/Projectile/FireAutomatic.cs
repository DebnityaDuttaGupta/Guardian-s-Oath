using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAutomatic : MonoBehaviour
{
    public Transform firepoint;
    public GameObject homingProjectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 3f, 3f);
    }

    private void Shoot()
    {
        Instantiate(homingProjectilePrefab, firepoint.position, firepoint.rotation);
    }
}
