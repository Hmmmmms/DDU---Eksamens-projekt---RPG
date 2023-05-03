using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public bool isOpen = false;
    public Animator animator;

    public void OpenChest()
    {
        if (!isOpen)
        {
            isOpen = true;
            animator.SetBool("IsOpen", isOpen);
            GetComponent<LootBag>().InstantiateLoot(transform.position - LootBag.lootDropOffset);
        }
    }

}
