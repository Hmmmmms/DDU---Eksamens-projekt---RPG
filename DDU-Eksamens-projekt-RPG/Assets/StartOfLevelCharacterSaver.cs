using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOfLevelCharacterSaver : MonoBehaviour
{
    public GameObject StartOfScenePlayer;

    public GameObject CurrentScenePlayer;

    public void Start()
    {
        StartOfScenePlayer = CurrentScenePlayer;
    }

    public void StartAtLevelStartWithLevelStartCharacter()
    {
        CurrentScenePlayer = StartOfScenePlayer;
    }
}
