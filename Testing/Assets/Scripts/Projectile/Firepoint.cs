using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firepoint : MonoBehaviour
{
    public Transform firepoint;
    public GameObject firepointPrefab;
    public float attackDelay = 2f; // Set the delay in seconds
    public float fireballSpeed = 10f; // Set the speed of the fireball

    private ProperMovement movementScript;

    void Start()
    {
        // Find and store the DifferentMovement script on the player
        movementScript = GetComponentInParent<ProperMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(ShootWithDelay());
        }
    }


    IEnumerator ShootWithDelay()
    {
        movementScript.SetAttackAnimation();

        yield return new WaitForSeconds(attackDelay);

        Shoot();

        yield return null;
    }

    private void Shoot()
    {
        GameObject fireball = Instantiate(firepointPrefab, firepoint.position, Quaternion.identity);

        Rigidbody rb = fireball.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 shootDirection = transform.localScale.x > 0 ? Vector3.right : Vector3.left;

            fireball.transform.rotation = Quaternion.LookRotation(shootDirection);

            rb.velocity = shootDirection * fireballSpeed;
        }
        else
        {
            Debug.LogError("Rigidbody component not found on the fireballPrefab.");
        }
    }

}
