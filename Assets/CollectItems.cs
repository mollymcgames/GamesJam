using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectItems : MonoBehaviour
{
    public static bool allPiecesCollected = false; // Static variable to track collection status
    public TextMeshProUGUI partsCollectedText; // Reference to the TextMeshPro UI element
    private HashSet<GameObject> collectedItems = new HashSet<GameObject>();

    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip collectSound; // Reference to the AudioClip to play

    void Start()
    {
        UpdateCollectedItemsDisplay(); // Initial display update
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            collectedItems.Add(other.gameObject);
            other.gameObject.SetActive(false); // Hides the GameObject from the scene
            UpdateCollectedItemsDisplay();

            PlayCollectSound(); // Play sound when an item is collected


            if (collectedItems.Count == 10)
            {
                allPiecesCollected = true;
                CompletePuzzle();
            }
        }
    }

    void PlayCollectSound()
    {
        if (audioSource != null && collectSound != null)
            audioSource.PlayOneShot(collectSound); // Play the collect sound
    }

    void UpdateCollectedItemsDisplay()
    {
        if (partsCollectedText != null)
            partsCollectedText.text = collectedItems.Count.ToString() + "/10";
    }

    void CompletePuzzle()
    {
        Debug.Log("All pieces collected. Puzzle complete!");
    }
}
