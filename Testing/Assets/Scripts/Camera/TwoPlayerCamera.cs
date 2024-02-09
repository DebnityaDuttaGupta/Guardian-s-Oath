using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPlayerCamera : MonoBehaviour
{
    public Transform[] players;
    public Vector2 minBounds;
    public Vector2 maxBounds;
    public float smoothTime = 0.5f;

    private Vector3 velocity;

    void LateUpdate()
    {
        if (players.Length == 0)
            return;

        
        Vector3 centerPoint = GetCenterPoint();

        
        float clampedX = Mathf.Clamp(centerPoint.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(centerPoint.y, minBounds.y, maxBounds.y);

        
        Vector3 targetPosition = new Vector3(clampedX, clampedY, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    Vector3 GetCenterPoint()
    {
        if (players.Length == 1)
            return players[0].position;

        
        Vector3 centerPoint = (players[0].position + players[1].position) / 2f;
        return centerPoint;
    }
}
