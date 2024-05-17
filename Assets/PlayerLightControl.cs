using UnityEngine;
using TMPro; // Include the TextMeshPro namespace
using System.Collections;

public class PlayerLightControl : MonoBehaviour
{
    public Light playerLight; // Assign this in the inspector
    public TextMeshProUGUI statusText; // Use TextMeshProUGUI for UI text

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Candle")
        {
            StartCoroutine(ActivateLight());
            Destroy(other.gameObject); // Destroys the candle object upon collision
            if (statusText != null) // Check if the statusText is assigned
            {
                statusText.text = "Candle picked up. Will turn off in 15 sec.";
                StartCoroutine(ClearTextAfterDelay(1)); // Clear text after 1 second
            }
        }
    }

    IEnumerator ActivateLight()
    {
        playerLight.enabled = true; // Turn on the light
        yield return new WaitForSeconds(15); // Wait for 15 seconds
        playerLight.enabled = false; // Turn off the light
    }

    IEnumerator ClearTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        statusText.text = ""; // Clear the text
    }
}
