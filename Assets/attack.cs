using UnityEngine;

public class Attack : MonoBehaviour
{
    // Optional: If you want to fine-tune which layer can be hit, use a LayerMask
    public LayerMask playerLayer;

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider that we've hit has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Attempt to get a player health component script
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Reduce the health of the player
                playerHealth.ReduceHealth(10);
            }
        }
    }
}
