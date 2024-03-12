using System.Collections;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public Transform Firepoint;

    public GameObject beamAttackPrefab;

    public HealthBar healthBar;

    private bool beamAttackActivated = false;

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
        else if (currentHealth <= maxHealth * 0.2f && !beamAttackActivated)
        {
            ActivateBeamAttack();
            beamAttackActivated=true;
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

    void ActivateBeamAttack()
    {
        if (beamAttackPrefab != null)
        {
            GameObject beamAttack = Instantiate(beamAttackPrefab, Firepoint.position, Firepoint.rotation);

            BeamAttack beamAttackScript = beamAttack.GetComponent<BeamAttack>();
            if (beamAttackScript != null)
            {
                beamAttackScript.OnBeamAttackFinished -= DestroyBoss;
            }
        }
    }
}