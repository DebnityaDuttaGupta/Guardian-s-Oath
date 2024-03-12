using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject triggerObject;

    void Start()
    {
        gameObject.SetActive(false);    
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
