using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private void Update()
    {
        // Move the platform back and forth between pointA and pointB continuously
        float pingPongValue = Mathf.PingPong(Time.time * speed, 1.0f);
        transform.position = Vector3.Lerp(pointA.position, pointB.position, pingPongValue);
    }
}
