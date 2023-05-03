using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen;

    public Animator animator;

    //public AudioClip doorSoundEffect;

    public void OpenDoor(GameObject obj)
    {
        if (!isOpen)
        {
            InventoryController manager = obj.GetComponent<InventoryController>();
            if (manager)
            {
                if (manager.keyCount > 0)
                {
                    isOpen = true;

                    //AudioSource.PlayClipAtPoint(doorSoundEffect, transform.position);

                    animator.SetBool("IsOpen", isOpen);
                    manager.UseDoorKey();
                }
            }
        }
        else
        {

        }
    }
}
