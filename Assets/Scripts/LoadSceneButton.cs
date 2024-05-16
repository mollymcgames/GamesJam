using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
    public string sceneToLoad = "CastleScene"; // Replace with your scene name

    void Start()
    {
        // Get the Button component and add a listener to it
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(LoadTargetScene);
        }
    }

    void LoadTargetScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
