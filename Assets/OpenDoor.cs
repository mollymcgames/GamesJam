using UnityEngine;
using TMPro;
using System.Collections; // Required for IEnumerator

public class OpenDoor : MonoBehaviour
{
    public float doorRotation = 90f; // Define the rotation of the door
    public TextMeshProUGUI messageText; // Reference to the TextMeshPro UI text element

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (CollectItems.allPiecesCollected) // Check if all pieces have been collected
            {
                ShowMessage("The door is now open!", 1.0f);
                Debug.Log("Colliding with the painting");
                GameObject door = GameObject.FindGameObjectWithTag("door");
                if (door != null)
                {
                    Debug.Log("Door found");
                    // door.transform.Rotate(0f, doorRotation, 0f);
                    Destroy(door); // Optionally rotate or destroy the door
                }
                else
                {
                    Debug.LogError("Door not found");
                    ShowMessage("Error: Door not found!", 1.0f);
                }
            }
            else
            {
                ShowMessage("Missing pieces, cannot open the door.", 1.0f);
                Debug.Log("Missing pieces, cannot open the door.");
            }
        }
    }

    // Coroutine to show a message for a certain duration
    IEnumerator ShowMessageForTime(string message, float delay)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true); // Make sure the text is visible
        yield return new WaitForSeconds(delay);
        messageText.gameObject.SetActive(false); // Hide the text after the delay
    }

    // Helper method to start the coroutine
    void ShowMessage(string message, float delay)
    {
        StartCoroutine(ShowMessageForTime(message, delay));
    }
}
