using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableDoor : MonoBehaviour
{
    InventoryController inventoryController;

    public bool isInRange;
    public KeyCode interactKey;
    public DoorController interactAction;

    public void Update()
    {
        if (isInRange)//If we're in range
        {
            if (Input.GetKeyDown(interactKey)) //And player presses key
            {
                interactAction.OpenDoor(inventoryController);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            inventoryController = collision.gameObject.GetComponent<InventoryController>();
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
