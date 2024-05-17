using UnityEngine;
using UnityEngine.UI;  // This is necessary for UI manipulation
using TMPro;  // Include the TextMeshPro namespace

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;       // Starting health for the player
    public TextMeshProUGUI healthDisplay; // UI TextMeshPro component to display the health

    private void Start()
    {
        UpdateHealthDisplay();  // Initial update to the health display
        Debug.Log("Health system initialized. Current health: " + health);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name); // Logs the name of the colliding object

        if (collision.gameObject.CompareTag("Ghost"))
        {
            Debug.Log("Collided with Ghost. Health will be decremented.");
            health -= 10;  // Reduce health by 10 when colliding with a ghost
            UpdateHealthDisplay();  // Update the UI text

            if (health <= 0)
            {
                Debug.Log("Player is dead.");
                // Implement what happens when the player dies (e.g., restart the game, show a game over screen)
            }
        }
        else
        {
            Debug.Log("Collision ignored. Not a Ghost.");
        }
    }

    void UpdateHealthDisplay()
    {
        if (healthDisplay != null)  // Check if the healthDisplay is linked
        {
            healthDisplay.text = health.ToString();  // Update the health display to just show the number
        }
    }
}
