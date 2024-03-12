using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAttack : MonoBehaviour
{
    public float damagePercentage = 0.05f;
    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 2f;
    public float waitTime = 5f;

    private SpikeManager spikeManager;
    private bool hasAttacked = false;

    void Start()
    {

    }

    public void Initialize(SpikeManager manager)
    {
        spikeManager = manager;
    }

    public void TriggerSpikeAttack()
    {
        if (!hasAttacked)
        {
            StartCoroutine(MoveSpike());
            hasAttacked = true;
        }
    }

    public IEnumerator MoveSpike()
    {
        float journeyTimeAB = Vector3.Distance(transform.position, pointB.position) / moveSpeed;
        float startTimeAB = Time.time;

        while (Time.time < startTimeAB + journeyTimeAB)
        {
            transform.position = Vector3.Lerp(pointA.position, pointB.position, (Time.time - startTimeAB) / journeyTimeAB);
            yield return null;
        }

        yield return new WaitForSeconds(waitTime);

        float journeyTimeBA = Vector3.Distance(transform.position, pointA.position) / moveSpeed;
        float startTimeBA = Time.time;

        while (Time.time < startTimeBA + journeyTimeBA)
        {
            transform.position = Vector3.Lerp(pointB.position, pointA.position, (Time.time - startTimeBA) / journeyTimeBA);
            yield return null;
        }

        spikeManager.SpikesFinishedAttack();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthLevel4 playerHealth = other.GetComponent<HealthLevel4>();
            if (playerHealth != null)
            {
                // Calculate damage based on damagePercentage
                int damage = Mathf.CeilToInt(playerHealth.maxHealth * damagePercentage);
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
