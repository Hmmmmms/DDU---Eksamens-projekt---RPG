using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelLoader : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            LoadNextLevel();
        }
    }
    public void LoadNextLevel()
    {
        FindObjectOfType<PlayerController>().DeNotifyPlayer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
