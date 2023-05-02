using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class TaskAttack_Skeleton : Node
{
    private Transform _transform;
    private Animator _animator;
    private Rigidbody2D _rb;
    private DamagableCharacter _damagableCharacterEnemy;

    float attackTimer = 0.1f;

    public TaskAttack_Skeleton(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if(target != null)
        {
            _damagableCharacterEnemy = target.GetComponent<DamagableCharacter>();


            _animator.SetBool("isMoving", false);

            
            if (_damagableCharacterEnemy.isAlive == true)
            {
                if (attackTimer <= 0f) { attackTimer = 1f; }

                //wait for attack
                if (attackTimer > 0f)
                {
                    attackTimer -= Time.deltaTime;
                    if (attackTimer <= 0f)
                    {
                        _animator.SetTrigger("Skeleton_attack");
                        attackTimer = 0f; // reset cooldown
                    }
                }
            }
            else
            {
                ClearData("target");
            }

            
        }

        state = NodeState.RUNNING;
        return state;
    }

}
