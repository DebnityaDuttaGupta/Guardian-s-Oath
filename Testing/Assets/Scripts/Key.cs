using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            // Player collected the key
            Destroy(gameObject); // Remove the key from the scene
            // You may want to add some visual/audio effects here
            col.GetComponent<ProperMovement>().HasKey = true; // Set a flag in the player script
        }
    }
}
