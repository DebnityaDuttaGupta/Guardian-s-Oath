using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionTrap : MonoBehaviour
{
    [SerializeField] public GameObject Trap;
    void Start()
    {
        Trap.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Trap.SetActive(true);
        }
    }
}
