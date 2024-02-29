using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class GatController : MonoBehaviour
{
    public GameObject boss;

    public GameObject gate;

    void Start()
    {
        Debug.Log("Gate Controller Start");

        gate.SetActive(false);

        if (boss != null)
        {
            BossHealth bossHealth = boss.GetComponent<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.OnBossDestroyed += EnableGate;
            }
            else
            {
                Debug.LogError("BossHealth script not found on the boss GameObject.");
            }
        }
        else
        {
            EnableGate();
        }
    }

    // Method to enable the gate
    void EnableGate()
    {
        Debug.Log("Gate Enabled");
        gate.SetActive(true);

        if (boss != null)
        {
            boss.GetComponent<BossHealth>().OnBossDestroyed -= EnableGate;
        }
    }
}
