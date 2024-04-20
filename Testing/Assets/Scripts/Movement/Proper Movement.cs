using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProperMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 10f;
    public float groundCheckDistance = 0.1f;
    public float jumpCooldown = 0.5f;
    public float attackAnimationDuration = 3.0f;
    private float lastJumpTime = 0f;

    public bool isGrounded;
    public bool HasKey { get; set; } = false;
    private bool isJumping = false;

    private Transform groundCheck;
    private Rigidbody rb;
    private Animator anim;

    private MovingPlatform currentMovingPlatform;
    private Quaternion initialRotation;

    private void Start()
    {
        groundCheck = transform.Find("GroundCheck");
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        currentMovingPlatform = GetComponent<MovingPlatform>();
        // Set the initial rotation
        transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        anim.SetFloat("Blend", 0f);

        // Ensure rigidbody uses gravity
        rb.useGravity = true;

        initialRotation = transform.rotation;
    }

    private void Update()
    {
        CheckGrounded();
        HandleJumpInput();

        if (isGrounded && CheckIfOnMovingPlatform())
        {
            //transform.parent = currentMovingPlatform.transform;
            Vector3 platformMovement = currentMovingPlatform.GetPlatformMovement();
            transform.position += platformMovement;
        }
        else
        {
            transform.parent = null;
        }
    }

    

    private void FixedUpdate()
    {
        HandleMovementInput();
        HandleDirection();
        HandleJump();


        transform.rotation = initialRotation;
    }

    private void CheckGrounded()
    {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, LayerMask.GetMask("Ground"));

        isGrounded |= Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, LayerMask.GetMask("MovingPlatform"));

        isGrounded |= Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, LayerMask.GetMask("FallingTrap"));

        isGrounded |= Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, LayerMask.GetMask("Box"));
    }

    private void HandleMovementInput()
    {
        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        bool isMoving = Mathf.Abs(horizontalInput) > 0.01f;

        //Vector3 newPosition = transform.position + new Vector3(horizontalInput * moveSpeed * Time.fixedDeltaTime, 0f, 0f);
        transform.position += new Vector3(horizontalInput * moveSpeed * Time.fixedDeltaTime, 0f, 0f);
        
        //transform.position = newPosition;

        float idleBlend = 0f;
        float walkBlend = 0.2f;
        float runBlend = 0.4f;
        float jumpBlend = 0.6f;

        if (isGrounded)
        {
            float smoothBlend = Mathf.Lerp(anim.GetFloat("SmoothBlend"), isMoving ? (Input.GetKey(KeyCode.LeftShift) ? runBlend : walkBlend) : idleBlend, 0.1f);
            anim.SetFloat("SmoothBlend", smoothBlend);

            if (isMoving)
            {
                anim.SetFloat("Blend", anim.GetFloat("SmoothBlend"));
                
            }
            else
            {
                anim.SetFloat("Blend", 0f);
                FindAnyObjectByType<AudioManager>().Play("Running");
            }
        }
        else
        {
            anim.SetFloat("Blend", jumpBlend);
        }

        if (Input.GetButtonDown("Jump"))
        {
            anim.SetFloat("Blend", jumpBlend);
        }
    }

    private void HandleDirection()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(1f, 1f, -1f);
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void HandleJumpInput()
    {
        if (isGrounded && Input.GetKeyDown("space") && Time.time - lastJumpTime > jumpCooldown)
        {
            isJumping = true;
            lastJumpTime = Time.time;
        }
    }

    private void HandleJump()
    {
        if (isJumping)
        {
            anim.SetFloat("Blend", 0.6f);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = false;
        }
        else if (rb.velocity.y < 0 && isGrounded)
        {
            //float idleBlend = 0f;
            float walkBlend = 0.2f;
            float runBlend = 0.4f;
            float targetBlend = Input.GetKey(KeyCode.LeftShift) ? runBlend : walkBlend;
            float smoothBlend = Mathf.Lerp(anim.GetFloat("SmoothBlend"), targetBlend, 0.1f);
            anim.SetFloat("SmoothBlend", smoothBlend);

            anim.SetFloat("Blend", anim.GetFloat("SmoothBlend"));
        }
    }
    private bool CheckIfOnMovingPlatform()
    {
        // Check if the player is on the moving platform using a raycast
        RaycastHit hit;
        Vector3 raycastOrigin = transform.position + Vector3.up * 0.1f; // Adjust the raycast origin
        if (Physics.Raycast(raycastOrigin, Vector3.down, out hit, groundCheckDistance, LayerMask.GetMask("MovingPlatform")))
        {
            MovingPlatform platform = hit.collider.GetComponentInParent<MovingPlatform>();
            return (platform != null && platform == currentMovingPlatform);
        }
        return false;
    }

    public void SetAttackAnimation()
    {
        // Set the animation blend value for attack
        anim.SetFloat("Blend", 0.8f);
        StartCoroutine(WaitAndResetAnimation());
    }

    private IEnumerator WaitAndResetAnimation()
    {
        // Wait for the attack animation to complete
        yield return new WaitForSeconds(attackAnimationDuration);

        // Reset the animation blend value after the animation is complete
        anim.SetFloat("Blend", 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("HomingProjectile"))
        {
            Destroy(collision.gameObject);
        }
    }
}
