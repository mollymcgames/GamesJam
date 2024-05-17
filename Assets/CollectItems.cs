using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectItems : MonoBehaviour
{
    public static bool allPiecesCollected = false; // Static variable to track collection status
    public TextMeshProUGUI partsCollectedText; // Reference to the TextMeshPro UI element
    private HashSet<GameObject> collectedItems = new HashSet<GameObject>();

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

            if (collectedItems.Count == 10)
            {
                allPiecesCollected = true;
                CompletePuzzle();
            }
        }
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
