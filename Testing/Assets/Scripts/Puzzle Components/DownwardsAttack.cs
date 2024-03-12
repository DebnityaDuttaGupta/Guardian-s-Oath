using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownwardsAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject triggerObject;

    public float shootSpeed = 5f;
    public float initialDelay = 1f;
    public float autoAttackInterval = 3f;

    void Start()
    {
        gameObject.SetActive(false);
        InvokeRepeating("AutoAttack", initialDelay, autoAttackInterval);
    }

    void AutoAttack()
    {
        // Fire a projectile
        Shoot();
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

        DownFireball downFireball = projectile.GetComponent<DownFireball>();

        if (downFireball != null)
        {
            downFireball.SetDirection(Vector3.down * shootSpeed);
        }
        else
        {
            Debug.LogError("DownFireball component not found on the instantiated prefab.");
        }

        Destroy(projectile, 2f); // Assuming you want to destroy the projectile after a certain time
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == triggerObject)
        {
            gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == triggerObject)
        {
            gameObject.SetActive(false);
        }
    }
}
