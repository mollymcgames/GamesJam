using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 30f; // Set this to any number of seconds you need
    public TextMeshProUGUI timerText; // Reference to the TextMeshPro UI text element
    public Light[] lights; // Array of all light objects to be dimmed
    public Slider timeSlider;

    private float[] initialIntensities; // Array to store the initial intensity of each light
    private float totalDuration; // Total duration the timer is set for

    void Start()
    {
        totalDuration = timeRemaining; // Store the total duration based on the initial timeRemaining
        initialIntensities = new float[lights.Length];

        // Store each light's initial intensity
        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i] != null) // Check if the light reference is not null
                initialIntensities[i] = lights[i].intensity;
        }
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText(); // Update the text whenever the time changes
            UpdateLightIntensity(); // Update the light intensity
            UpdateSlider(); // Update the slider based on time
        }
        else
        {
            timeRemaining = 0;
            SceneManager.LoadScene("GameOver"); // Load the game over scene when time runs out
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void UpdateLightIntensity()
    {
        float timeFraction = timeRemaining / totalDuration; // This will start at 1 and go to 0 as the timer expires
        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i] != null) // Ensure the light reference is not null
            {
                float targetIntensity = Mathf.Lerp(0.2f, initialIntensities[i], timeFraction);
                lights[i].intensity = targetIntensity;
            }
        }
    }

    void UpdateSlider()
    {
        if (timeSlider != null)
        {
            timeSlider.value = (totalDuration - timeRemaining) / totalDuration * timeSlider.maxValue;
        }
    }
}
