using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;

    bool isAlive = true;

    public float Health
    {
        set {
            if (value < health)
            {
                animator.SetTrigger("Hit");
            }

            health = value; 

        if(health <= 0)
            {
                Defeated();
            }
        }
        get { return health; } 
    }

    public float health = 1;


    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", isAlive);
    }

    public void Defeated()
    {
        animator.SetBool("isAlive", false);
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }
    

}
