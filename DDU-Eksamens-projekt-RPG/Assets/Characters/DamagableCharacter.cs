using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamagableCharacter : MonoBehaviour, IDamageable
{

    Animator animator;

    Rigidbody2D rb;

    Collider2D physicsCollider;

    public bool canTurnInvincible = false;

    public bool dropLoot = false;

    public float invincibilityTime = 0.25f;

    public bool isAlive = true;

    private float invincibleTimeElapsed = 0f;

    public bool canMove = true;

    public float Health
    {
        set
        {
            if (value < health)
            {
                
                animator.SetTrigger("Hit");

                

            }

            health = value;

            if (health <= 0)
            {
                if (dropLoot)
                {
                    GetComponent<LootBag>().InstantiateLoot(transform.position + SlimeOffsetY);
                }
                //Maybe not needed
                Targetable = false;

                isAlive = false;

                Defeated();
            }
        }
        get { return health; }
    }

    public bool Targetable
    {
        get { return _targetable; }
        set
        {
            _targetable = value;

            
            rb.simulated = value;
            

            physicsCollider.enabled = value;
        }
    }

    public bool Invincible { get
        {
            return _invincible;
        } set
        {
            _invincible = value;

            if(_invincible == true)
            {
                invincibleTimeElapsed = 0f;
            }

        } }

    public float health = 1;

    bool _targetable = true;

    bool _invincible = false;

    bool _DialogueInviciblity = false;

    //Offset for Skeleton hitbox center compared to sprite center
    public static Vector3 SkeletonOffsetY = new Vector3(0.0f, 0.16f, 0.0f);

    //Offset for Slime hitbox center compared to sprite center
    public static Vector3 SlimeOffsetY = new Vector3(0.0f, 0.02f, 0.0f);

    //Offset for Playerhitbox center compared to sprite center
    public static Vector3 PlayerOffsetY = new Vector3(0.0f, 0.1f, 0.0f);

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("isAlive", isAlive);
        physicsCollider = GetComponent<Collider2D>();
    }

    public void Defeated()
    {
        animator.SetBool("isAlive", false);
    }

    public void RemoveObject()
    {
        Destroy(gameObject);
    }

    public void OnHit(float damage)
    {
        if (!Invincible && !_DialogueInviciblity)
        {
            Health -= damage;
        }
        if (canTurnInvincible)
        {
            Invincible = true;
        }

    }

    public void OnHit(float damage, Vector2 knockback)
    {
        if (!Invincible && !_DialogueInviciblity)
        {
            Health -= damage;
            //Apply force to slime
            rb.AddForce(knockback, ForceMode2D.Impulse);
            
        }
        if (canTurnInvincible)
        {
            Invincible = true;
        }
    }

    public void FixedUpdate()
    {
        //Become Invincible right after hit
        if (Invincible)
        {
            invincibleTimeElapsed += Time.deltaTime;

            if(invincibleTimeElapsed > invincibilityTime)
            {
                Invincible = false;
            }
        }
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }

    public void ToggleInvincibleEnabled()
    {
        _DialogueInviciblity = true;
    }
    public void ToggleInvincibleDisabled()
    {
        _DialogueInviciblity = false;
    }

    public void RestartLevelOnPlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
