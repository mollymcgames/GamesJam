using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private float direction = 0f;
    private float changeTime = 0f;

    void Update()
    {
        // Change direction at intervals
        if (Time.time >= changeTime)
        {
            direction = Random.Range(-3f, 3f); // Update direction less frequently
            changeTime = Time.time + 1f; // Change direction every 1 second
        }

        // Move the ghost forward and backward along the z-axis
        transform.position += new Vector3(0, 0, direction) * speed * Time.deltaTime;
    }
}
