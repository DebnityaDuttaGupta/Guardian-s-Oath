using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private float movespeed = 0f;
    [SerializeField] private float Jumpspeed = 1f;
    private Rigidbody rb;

    private float dirX = 0f;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * movespeed, rb.velocity.y);
        if (Input.GetButton("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, Jumpspeed);
        }
        Direction();

        Physics.IgnoreLayerCollision(7, 8);
    }

    private void Direction()
    {
        if (dirX > 0f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (dirX < 0f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
