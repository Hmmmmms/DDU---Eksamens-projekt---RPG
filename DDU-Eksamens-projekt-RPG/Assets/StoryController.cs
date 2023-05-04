using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{
    public KeyCode interactKey;

    public void Update()
    {
        
            if (Input.GetKeyDown(interactKey)) //And player presses key
            {
                StartGame();
            }
        
    }

    void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
