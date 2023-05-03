using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContinueDialogue : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;

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
            collision.gameObject.GetComponent<PlayerController>().NotifyPlayer();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            isInRange = false;
            collision.gameObject.GetComponent<PlayerController>().DeNotifyPlayer();
        }
    }

}
