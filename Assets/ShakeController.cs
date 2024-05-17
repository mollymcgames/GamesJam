using UnityEngine;
using System.Collections;

public class ShakeController : MonoBehaviour
{
    public CameraShake cameraShake;
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.5f;

    void Start()
    {
        StartCoroutine(ShakeRoutine());
    }

    IEnumerator ShakeRoutine()
    {
        // Loop indefinitely
        while (true)
        {
            yield return new WaitForSeconds(10f); // Wait for 10 seconds
            StartCoroutine(cameraShake.Shake(shakeDuration, shakeMagnitude)); // Start the shake
        }
    }
}
