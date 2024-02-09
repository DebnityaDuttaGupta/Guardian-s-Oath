using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_2_Movement : MonoBehaviour
{
    [SerializeField] private float move = 0f;
    [SerializeField] private float Jump = 1f;

    private Rigidbody rb;
    private Animator anim;
    
    public bool grounded = false;
    private float dirX1 = 0f;
    private enum MovementState{idle, running}

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        dirX1 = Input.GetAxisRaw("Horizontal1");

        rb.velocity = new Vector2(dirX1 * move, rb.velocity.y);
        if (Input.GetButton("Jump1") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, Jump);
        }
        
        UpdateAnimationUpdate();
        Direction();

        Physics.IgnoreLayerCollision(6, 8);
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.CompareTag("Ground"))
        {
            grounded = true;
        }
        
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            grounded = false;
        }
        
    }

    private void UpdateAnimationUpdate()
    {
        if (dirX1 > 0f)
        {
            anim.SetBool("running", true);
        }
        else if (dirX1 < 0f)
        {
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }
    }

    private void Direction()
    {
        if (dirX1 > 0f)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (dirX1 < 0f)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
    }
}
