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
        // Call the method in DifferentMovement to change the animation
        movementScript.SetAttackAnimation();

        // Wait for the attack delay
        yield return new WaitForSeconds(attackDelay);

        // Shoot the fireball
        Shoot();
    }

    private void Shoot()
    {
        // Instantiate the fireball
        GameObject fireball = Instantiate(firepointPrefab, firepoint.position, firepoint.rotation);

        // Get the Rigidbody component of the fireball
        Rigidbody rb = fireball.GetComponent<Rigidbody>();

        // Check if the Rigidbody is present
        if (rb != null)
        {
            // Set the velocity to make the fireball move forward
            rb.velocity = firepoint.forward * fireballSpeed;
        }
        else
        {
            Debug.LogError("Rigidbody component not found on the fireballPrefab.");
        }
    }
}
