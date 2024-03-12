using System.Collections;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    private bool playerOnPlatform = false;
    public GameObject platformPrefab; // Reference to the platform prefab

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerOnPlatform = true;
            StartCoroutine(DeactivateAndReactivateCoroutine());
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerOnPlatform = false;
        }
    }

    IEnumerator DeactivateAndReactivateCoroutine()
    {
        yield return new WaitForSeconds(5f);

        Destroy(platformPrefab); // Destroy the parent platform

        float timer = 0f;
        float waitTime = 3f;

        while (timer < waitTime)
        {
            // Check if the player has left the platform during the wait time
            if (!playerOnPlatform)
            {
                yield break; // Exit the coroutine if the player has left
            }

            timer += Time.deltaTime;
            yield return null;
        }

        // Reactivate the platform after the wait time by instantiating a new one
        Instantiate(platformPrefab, transform.parent.position, transform.parent.rotation);
    }
}
