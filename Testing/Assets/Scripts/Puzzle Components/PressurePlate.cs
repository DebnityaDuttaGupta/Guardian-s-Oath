using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject objectToAppear;
    private bool isPlayerOnPlate = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            isPlayerOnPlate = true;
            StartCoroutine(AppearAndDisappear());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            isPlayerOnPlate = false;
        }
    }

    private IEnumerator AppearAndDisappear()
    {
        // Activate object
        objectToAppear.SetActive(true);

        // Wait for 10 seconds
        yield return new WaitForSeconds(10f);

        // Deactivate object if the player is not on the plate
        if (!isPlayerOnPlate)
        {
            objectToAppear.SetActive(false);
        }
    }
}
