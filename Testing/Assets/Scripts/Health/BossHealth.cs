using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;

    public delegate void BossDestroyed();
    public event BossDestroyed OnBossDestroyed;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Fireball"))
        {
            Destroy(col.gameObject);
            TakeDamage(5);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            DestroyBoss();
        }
    }

    void DestroyBoss()
    {
        if (OnBossDestroyed != null)
        {
            OnBossDestroyed();
            Debug.Log("Boss Destroyed");
        }

        Destroy(gameObject);
    }
}
