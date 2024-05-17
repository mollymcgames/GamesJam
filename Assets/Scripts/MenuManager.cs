using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    // Method to start the game, loading the "Castle" scene
    public void StartGame()
    {
        SceneManager.LoadScene("Castle");
    }

    public void Options()
    {
        Debug.Log("Options button clicked");

    }


    public void QuitGame()
    {
        Debug.Log("Quit game requested");
        Application.Quit();
    }
}