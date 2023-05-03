using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadPlayerAtLastSavedCheckpoint : MonoBehaviour
{
    public void RestartLevelOnPlayerDeath()
    {
        FindObjectOfType<StartOfLevelCharacterSaver>().StartAtLevelStartWithLevelStartCharacter();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
