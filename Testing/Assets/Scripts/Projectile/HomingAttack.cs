using UnityEngine;

public class HomingAttack : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject target;
    private GameObject player1;

    [SerializeField] public float Speed = 1f;
    [SerializeField] public float RotateSpeed = 1f;
    [SerializeField] public float LifeTime = 5f; // Added a lifetime for the projectile

    private void Start()
    {
        player1 = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        target = player1;
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = new Vector3(0, 0, -rotateAmount) * RotateSpeed;
            rb.velocity = direction * Speed;
        }
    }

    private void Update()
    {
        // Move the destruction code to Update
        LifeTime -= Time.deltaTime;
        if (LifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            Destroy(gameObject);
        }
    }
}
