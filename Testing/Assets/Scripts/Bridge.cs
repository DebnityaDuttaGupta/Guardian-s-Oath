using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public GameObject bridge; // Reference to the bridge object
    public LayerMask activationLayer; // Layer(s) to check for activation (e.g., player or objects)

    private bool isActivated = false;

    void Start()
    {
        DeactivateBridge(); // Start with the bridge deactivated
    }

    void Update()
    {
        // Check if there are colliders on the activation layer within the button's bounds
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity, activationLayer);

        if (colliders.Length > 0)
        {
            if (!isActivated)
            {
                ActivateBridge();
            }
        }
        else
        {
            if (isActivated)
            {
                DeactivateBridge();
            }
        }
    }

    void ActivateBridge()
    {
        // Activate the bridge (set it active or enable its components)
        bridge.SetActive(true);
        isActivated = true;
    }

    void DeactivateBridge()
    {
        // Deactivate the bridge (set it inactive or disable its components)
        bridge.SetActive(false);
        isActivated = false;
    }

    // Draw the button's bounds in the scene view for visualization
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
