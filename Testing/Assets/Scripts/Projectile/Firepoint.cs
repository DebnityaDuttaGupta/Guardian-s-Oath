using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firepoint : MonoBehaviour
{
    public Transform firepoint;
    public GameObject firepointPrefab;

   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            for (int i =0; i < 1; i++)
            {
                shoot();
            }
        }
    }
    //rotae in z axis
    private void shoot()
    {
        Instantiate(firepointPrefab, firepoint.position, firepoint.rotation);
    }
}
