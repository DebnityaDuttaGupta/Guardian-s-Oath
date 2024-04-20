using System.Collections;
using UnityEngine;

public class BossHealth2 : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;

    public delegate void BossDestroyed();
    public event BossDestroyed OnBossDestroyed;

    private bool spikeAttack50Triggered = false;
    private bool spikeAttack10Triggered = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        OnBossDestroyed += GameManagerLevel4.instance.GameWin;
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
        else
        {
            float healthPercentage = (float)currentHealth / maxHealth;

            if (!spikeAttack50Triggered && healthPercentage <= 0.6f && healthPercentage > 0.4f)
            {
                Debug.Log("It works");
                spikeAttack50Triggered = true;
                TriggerSpikeAttack();
            }
            else if (!spikeAttack10Triggered && healthPercentage <= 0.2f && healthPercentage > 0f)
            {
                Debug.Log("It works");
                spikeAttack10Triggered = true;
                TriggerSpikeAttack();
            }
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

    void TriggerSpikeAttack()
    {
        SpikeManager spikeManager = FindObjectOfType<SpikeManager>();

        if (spikeManager != null)
        {
            spikeManager.TriggerAllSpikes();
        }
    }


}
