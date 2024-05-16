using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalInteraction : MonoBehaviour
{
    // Define the name of the scene to load when entering the portal
    public string winSceneName = "WinScreen";

    // Called when another collider enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider entering the trigger is tagged as "Player" (or whatever tag you've assigned to your player)
        if (other.CompareTag("Player"))
        {
            // Load the win scene
            SceneManager.LoadScene(winSceneName);
        }
    }
}
