using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLevel4 : MonoBehaviour
{
    private Rigidbody rb;
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        if (currentHealth == 0)
        {
            Destroy(rb.gameObject);
            GameManagerLevel4.instance.GameEnd();
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("HomingProjectile"))
        {
            Destroy(col.gameObject);
            TakeDamage(5);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
