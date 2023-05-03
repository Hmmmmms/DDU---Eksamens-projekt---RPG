using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObjsBetweenScenes : MonoBehaviour
{
    public static SaveObjsBetweenScenes instance;
    void Start()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        //Making sure the player is saved between scenes
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    
}
