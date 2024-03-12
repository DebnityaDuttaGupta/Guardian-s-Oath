using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BeamAttack : MonoBehaviour
{
    public Vector3 pointB = new Vector3(5f, 0f, 0f);
    public float scaleDuration = 0.5f;
    public float scaleYTarget = 18f;

    public Vector3 pointA = new Vector3(0f, 0f, 0f);
    private float startTime;

    public delegate void BeamAttackFinished();
    public event BeamAttackFinished OnBeamAttackFinished;

    void Start()
    {
        transform.Rotate(0f, 0f, 90f);
        pointA = transform.position;
        startTime = Time.time;

        Invoke("DestroyBeam", scaleDuration + 3f);
    }

    void DestroyBeam()
    {
        if (OnBeamAttackFinished != null)
        {
            OnBeamAttackFinished();
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();

            if (playerHealth != null)
            {
                int damage = Mathf.RoundToInt(playerHealth.maxHealth * 0.2f);

                playerHealth.TakeDamage(damage);
            }
        }
    }

    void Update()
    {
        float t = (Time.time - startTime) / scaleDuration;

        transform.position = Vector3.Lerp(pointA, pointB, t);

        Vector3 scale = transform.localScale;
        scale.y = Mathf.Lerp(0f, scaleYTarget, t);
        transform.localScale = scale;

        if (t >= 1.0f)
        {
            enabled = false;
        }
    }
}
