using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public GameObject bridge; // Reference to the bridge GameObject
    public Transform activationCube; // Reference to the cube that triggers the bridge
    public float activationTime = 3f; // Time to wait before the bridge appears
    public float bridgeDuration = 10f; // Duration for the bridge to stay active

    private bool bridgeActivated = false;
    private float timer = 0f;

    private void Update()
    {
        // Check if the player is on the activation cube
        if (IsPlayerOnCube())
        {
            timer += Time.deltaTime;

            // Activate the bridge if the timer exceeds activation time
            if (timer >= activationTime && !bridgeActivated)
            {
                ActivateBridge();
            }
        }
        else
        {
            // Reset the timer if the player leaves the cube
            timer = 0f;

            // Deactivate the bridge when leaving the cube
            if (bridgeActivated)
            {
                DeactivateBridge();
            }
        }

        // If the bridge is activated, count down the duration
        if (bridgeActivated)
        {
            bridgeDuration -= Time.deltaTime;

            // Deactivate the bridge after the specified duration
            if (bridgeDuration <= 0f)
            {
                DeactivateBridge();
            }
        }
    }

    private bool IsPlayerOnCube()
    {
        // You may need to adjust the size of the cube collider or use other methods
        // to check if the player is on the cube
        Collider cubeCollider = activationCube.GetComponent<Collider>();
        return cubeCollider.bounds.Contains(transform.position);
    }

    private void ActivateBridge()
    {
        bridge.SetActive(true);
        bridgeActivated = true;
    }

    private void DeactivateBridge()
    {
        bridge.SetActive(false);
        bridgeActivated = false;
        timer = 0f; // Reset the timer when the bridge deactivates
        bridgeDuration = 10f; // Reset the duration for the next activation
    }
}
