using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{

    //define the rotation of the door 
    public float doorRotation = 90f;

    // Called when another collider enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider entering the trigger is tagged as "Player" (or whatever tag you've assigned to your player)
        if (other.CompareTag("Player"))
        {
            Debug.Log("Colliding with the painting");
            // rotate the door by 90 degrees on the y-axis 
            GameObject door = GameObject.FindGameObjectWithTag("door");
            if (door != null)
            {
                Debug.Log("Door found");
                // door.transform.Rotate(0f, doorRotation, 0f);
                //Destroy the door after the player interacts with the painting
                Destroy(door);

            }
            else
            {
                Debug.LogError("Door not found");
            }

            //2. Write some code where the player can only do this IF they pick up the puzzle peices- 
            // on collision enter disappear the puzzle piece and add to a counter
            //For the jigsaw pieces try to make the asset from the peice  
        }
    }
}
