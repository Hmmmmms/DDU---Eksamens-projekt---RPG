using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOfLevelCharacterSaver : MonoBehaviour
{
    public GameObject StartOfScenePlayer;

    public GameObject CurrentScenePlayer;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAtLevelStartWithLevelStartCharacter()
    {
        CurrentScenePlayer = StartOfScenePlayer;
    }
}
