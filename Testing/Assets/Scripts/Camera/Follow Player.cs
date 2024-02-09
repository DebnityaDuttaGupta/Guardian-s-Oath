using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player1;
    public Transform player2;

    public Vector3 offset = new Vector3(0f, 0f, -10f);
    [SerializeField] public float minDistance = 2f;
    [SerializeField] public float smoothTime = 0.5f;
    

    private Vector3 velocity;

    void LateUpdate()
    {
        if (player1 != null && player2 != null)
        {
            Vector3 midpoint = (player1.position + player2.position) / 2f;

            float distance1 = Vector3.Distance(transform.position, player1.position);
            float distance2 = Vector3.Distance(transform.position, player2.position);

            if (distance1 > minDistance && distance2 > minDistance)
            {
                Vector3 targetPosition = midpoint + offset;
                transform.position = Vector3.SmoothDamp(targetPosition, targetPosition, ref velocity, smoothTime);
            }
        }
    }
}
