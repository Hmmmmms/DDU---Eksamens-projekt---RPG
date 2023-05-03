using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public bool isOpen;

    public Animator animator;

    public int NextLevel;

    //public AudioClip doorSoundEffect;

    public void OpenDoor(InventoryController obj)
    {
        if (!isOpen)
        {
            InventoryController manager = obj;
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + NextLevel);
        }
    }
}
