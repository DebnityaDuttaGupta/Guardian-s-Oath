using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HomingAttack : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject target;
    private GameObject player1;
     GameObject player2;

    [SerializeField] public float Speed = 1f;
    [SerializeField] public float RotateSpeed = 1f;
    private void Start()
    {
        player1 = GameObject.Find("Player");
        player2 = GameObject.Find("Player2");
        rb = GetComponent<Rigidbody>();

        FindClosestPlayer();
    }

    private void FindClosestPlayer()
    {
        float distanceToPlayer1 = Vector3.Distance(transform.position, player1.transform.position);
        float distanceToPlayer2 = Vector3.Distance(transform.position, player2.transform.position);

        target = (distanceToPlayer1 < distanceToPlayer2) ? player1 : player2;
    }

    private void FixedUpdate()
    {
        if (target != null)
        {

            Vector3 direction = target.transform.position - transform.position;
            direction.Normalize();
            direction.z = 0f;

            float rotateAmmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = new Vector3(9, 0, -rotateAmmount) * RotateSpeed;
            rb.velocity = new Vector3(direction.x, direction.y, 0f) * Speed;

            Destroy(rb.gameObject, 5f);
        }
    }
}
