using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedAppearance : MonoBehaviour
{
    public GameObject myObject;
    public float time;
    void Start()
    {
        myObject.SetActive(false);
        Invoke("ShowObject", time);
    }

    void ShowObject()
    {
        myObject.SetActive(true);
    }
}
