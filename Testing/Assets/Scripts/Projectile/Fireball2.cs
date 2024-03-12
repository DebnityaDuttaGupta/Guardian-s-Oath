using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball2 : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    public Rigidbody rb;

    // New variable to store the shooting direction
    private Vector3 shootDirection;

    // Method to set the shooting direction
    public void SetDirection(Vector3 direction)
    {
        shootDirection = direction.normalized;
        rb.velocity = shootDirection * speed;
    }

    void Start()
    {
        // Use the initial direction (you can set it in the inspector or code)
        SetDirection(Vector3.left);
    }

    private void Update()
    {
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            Destroy(gameObject);
        }
    }
}
