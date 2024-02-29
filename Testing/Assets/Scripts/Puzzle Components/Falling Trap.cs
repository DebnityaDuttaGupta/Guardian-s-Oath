using System.Collections;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    public Transform initialPosition;
    public Transform targetPosition;
    public float fallSpeed = 5f;
    public float returnSpeed = 2f;
    public float waitTime = 5f;

    private bool isFalling = false;
    private bool isWaiting = false;

    void Update()
    {
        if (isFalling)
        {
            // Fall down
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

            // Check if reached targetPosition
            if (transform.position.y <= targetPosition.position.y)
            {
                isFalling = false;
                StartCoroutine(WaitAndReturn());
            }
        }
    }
    public void ActivateTrap()
    {
        if (!isFalling && !isWaiting)
        {
            // Start falling immediately
            isFalling = true;
        }
    }

    IEnumerator WaitAndReturn()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);

        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;

        while (elapsedTime < returnSpeed)
        {
            transform.position = Vector3.Lerp(startPosition, initialPosition.position, elapsedTime / returnSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is exactly at the initial position
        transform.position = initialPosition.position;

        isWaiting = false;
    }
}
