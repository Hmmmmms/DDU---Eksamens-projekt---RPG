using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LostHeart : MonoBehaviour, ICollectable
{
    public void Collect()
    {

        Destroy(gameObject);

        FindObjectOfType<SaveObjsBetweenScenes>().DeleteCharacterOnRestart();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}