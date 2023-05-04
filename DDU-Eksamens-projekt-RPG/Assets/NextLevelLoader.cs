using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelLoader : MonoBehaviour
{
    public void LoadNextLevel()
    {
        FindObjectOfType<PlayerController>().DeNotifyPlayer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
