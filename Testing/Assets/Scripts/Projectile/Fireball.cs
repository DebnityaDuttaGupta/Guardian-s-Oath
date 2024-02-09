using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] public float speed = 1f;
    public Rigidbody rb;
    
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        Destroy(gameObject, 2f);
    }
}
