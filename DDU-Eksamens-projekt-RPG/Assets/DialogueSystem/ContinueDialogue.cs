using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContinueDialogue : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;

    public bool BossScene = false;

    public void Update()
    {
        if (isInRange)//If we're in range
        {
            if (Input.GetKeyDown(interactKey)) //And player presses key
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            isInRange = true;
            
            if (!BossScene)
            {
                collision.gameObject.GetComponent<PlayerController>().NotifyPlayer();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            isInRange = false;
            if (!BossScene)
            {
                collision.gameObject.GetComponent<PlayerController>().DeNotifyPlayer();
            }
            
        }
    }

}
