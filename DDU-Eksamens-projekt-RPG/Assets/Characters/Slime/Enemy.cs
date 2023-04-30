using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    

    public bool IsMoving
    {
        set
        {
            isMoving = value;
            animator.SetBool("isMoving", isMoving);
        }
    }

    private bool isMoving = false;

    private bool canMove = true;

    public DetectionZone detectionZone;

    public float moveSpeed = 250f;

    Vector2 direction = new Vector2 (0,0);

    //Here it you can choose if you are using the slimes or the skeletons offset for the movement calculation
    public bool SlimeOffset = false;

    public bool SkeletonOffset = false;

    Vector3 OffsetYEnemy;

    DamagableCharacter damagableCharacter;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        damagableCharacter = GetComponent<DamagableCharacter>();
        animator.SetFloat("Last_Horizontal", 1);
    }

    private void FixedUpdate()
    {
        //Set which way Enemy is facing
        animator.SetFloat("Horizontal", direction.x);


        //Set last direction the Enemy is facing. So that idle, hit and attack direction is set.
        if (direction.x > 0)
        {
            animator.SetFloat("Last_Horizontal", 1);
        }
        if(direction.x < 0)
        {
            animator.SetFloat("Last_Horizontal", -1);
        }
        

            if (damagableCharacter.Targetable && detectionZone.detectedObjs.Count > 0)
            {

                if(SlimeOffset)
                {
                    OffsetYEnemy = DamagableCharacter.SlimeOffsetY;
                }
                if(SkeletonOffset){
                    OffsetYEnemy = DamagableCharacter.SkeletonOffsetY;
                }


                //Calculate the direction to the target
                direction = ((detectionZone.detectedObjs[0].transform.position - DamagableCharacter.PlayerOffsetY) - (transform.position - OffsetYEnemy)).normalized;

            //Move Towards detected object
            if (canMove)
            {
                rb.AddForce(direction * moveSpeed * Time.fixedDeltaTime);

                IsMoving = true;
            }
            }
            else
            {
                IsMoving = false;
            }
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockLockMovement()
    {
        canMove = true;
    }

}
