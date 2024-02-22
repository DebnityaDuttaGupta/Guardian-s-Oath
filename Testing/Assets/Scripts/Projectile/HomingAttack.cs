using UnityEngine;

public class HomingAttack : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject target;
    private GameObject player1;

    [SerializeField] public float Speed = 1f;
    [SerializeField] public float RotateSpeed = 1f;

    private void Start()
    {
        player1 = GameObject.Find("Player2");
        rb = GetComponent<Rigidbody>();
        target = player1;
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            direction.Normalize();
            direction.z = 0f;

            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = new Vector3(9, 0, -rotateAmount) * RotateSpeed;
            rb.velocity = new Vector3(direction.x, direction.y, 0f) * Speed;

            Destroy(rb.gameObject, 5f);
        }
    }
}
