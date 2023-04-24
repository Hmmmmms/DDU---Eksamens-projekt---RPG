using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour, IDamageable
{
    Animator animator;

    Rigidbody2D rb;

    Collider2D physicsCollider;

    bool isAlive = true;

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
                //Maybe not needed
                //Targetable = false;
                
                Defeated();
            }
        }
        get { return health; }
    }

    public bool Targetable { get { return _targetable; }
        set {
            _targetable = value;

            physicsCollider.enabled = value;
        } }

    public float health = 1;

    public bool _targetable = true; 

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

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }

    public void OnHit(float damage)
    {
        Health -= damage;
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;
        //Apply force to slime
        rb.AddForce(knockback);
    }

    
}
