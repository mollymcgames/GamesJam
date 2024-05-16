using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 30f; // set this to any number of seconds you need

    public TextMeshProUGUI timerText; // Reference to the Text object in the UI
    // public TextMeshProUGUI Text timerText; // Reference to the Text object in the UI


    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText(); // Update the text whenever the time changes

        }
        else
        {
            timeRemaining = 0;
            SceneManager.LoadScene("GameOver"); // Replace "LoseScene" with your loss scene's name
        }
    }
    void UpdateTimerText()
    {
        // Display the timer in minutes and seconds
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        string text = string.Format("{0:00}:{1:00}", minutes, seconds);

        timerText.text = text; // Update the Text object's text property
    }    

    // void OnGUI()
    // {
    //     GUIStyle guiStyle = new GUIStyle(GUI.skin.label);
    //     guiStyle.fontSize = 32; // Change font size as needed
    //     guiStyle.normal.textColor = Color.white; // Change text color as needed

    //     // Display the timer in minutes and seconds
    //     int minutes = Mathf.FloorToInt(timeRemaining / 60);
    //     int seconds = Mathf.FloorToInt(timeRemaining % 60);
    //     string text = string.Format("{0:00}:{1:00}", minutes, seconds);

    //     GUI.Label(new Rect(10, 10, 200, 50), text, guiStyle);
    // }
}
