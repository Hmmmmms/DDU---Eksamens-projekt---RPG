using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveObjsBetweenScenes : MonoBehaviour
{
    public static SaveObjsBetweenScenes instance;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (instance == null)
            {
                instance = this;
                //Making sure the player is saved between scenes
                GameObject.DontDestroyOnLoad(this.gameObject);

            }
            else
            {
                Destroy(this.gameObject);
                return;
            }
        }
        
    }

    public void DeleteCharacterOnRestart()
    {
        Destroy(this.gameObject);
    }
    
}
