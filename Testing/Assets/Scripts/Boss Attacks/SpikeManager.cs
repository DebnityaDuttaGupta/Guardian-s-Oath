using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    public List<SpikeAttack> spikes;

    void Start()
    {
        foreach (var spike in spikes)
        {
            spike.Initialize(this);
            StartCoroutine(spike.MoveSpike());
        }
    }

    public void TriggerAllSpikes()
    {
        foreach (var spike in spikes)
        {
            spike.TriggerSpikeAttack();
        }
    }

    public void SpikesFinishedAttack()
    {
        Debug.Log("All spikes finished attacking");
    }
}
