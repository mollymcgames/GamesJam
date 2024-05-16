using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 30f; // set this to any number of seconds you need

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 0;
            SceneManager.LoadScene("GameOver"); // Replace "LoseScene" with your loss scene's name
        }
    }

    void OnGUI()
    {
        GUIStyle guiStyle = new GUIStyle(GUI.skin.label);
        guiStyle.fontSize = 32; // Change font size as needed
        guiStyle.normal.textColor = Color.white; // Change text color as needed

        // Display the timer in minutes and seconds
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        string text = string.Format("{0:00}:{1:00}", minutes, seconds);

        GUI.Label(new Rect(10, 10, 200, 50), text, guiStyle);
    }
}
