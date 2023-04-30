using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Attack : MonoBehaviour
{
    Rigidbody2D rb;

    Animator animator;

    public AttackZone attackZone;

    float attackTimer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (attackZone.detectedObjs.Count > 0)
        {
            if (attackTimer <= 0f) attackTimer = 1.5f; // wait 1 second before attacking
            //wait for attack
            if (attackTimer > 0f)
            {
                attackTimer -= Time.deltaTime;
                if (attackTimer <= 0f)
                {
                    animator.SetTrigger("Skeleton_attack");
                    attackTimer = 0f; // reset cooldown
                }

            }  
        }

        
    }



}
