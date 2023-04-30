using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TaskGoToTarget_Slime : Node
{
    private Transform _transform;
    private Animator _animator;
    private Rigidbody2D _rb;

    private DamagableCharacter _damagableCharacterSkeleton;

    Vector2 direction = new Vector2(0, 0);

    public TaskGoToTarget_Slime(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
        _rb = transform.GetComponent<Rigidbody2D>();
        _damagableCharacterSkeleton = transform.GetComponent<DamagableCharacter>();
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        

        if (Vector2.Distance(_transform.position, (target.position - (DamagableCharacter.PlayerOffsetY - DamagableCharacter.SlimeOffsetY))) > 0.01f && _damagableCharacterSkeleton.canMove == true)
        {
            //Move the skeleton towards the player
            _transform.position = Vector2.MoveTowards(_transform.position, (target.position -(DamagableCharacter.PlayerOffsetY - DamagableCharacter.SlimeOffsetY)), SlimeBT.speed * Time.deltaTime);
            _animator.SetBool("isMoving", true);

            //Decide the direction the Skeleton is moving
            direction = ((target.transform.position - DamagableCharacter.PlayerOffsetY) - (_transform.position - DamagableCharacter.SlimeOffsetY)).normalized;
            

            //Set which way Enemy is facing
            _animator.SetFloat("Horizontal", direction.x);


            //Set last direction the Enemy is facing. So that idle, hit and attack direction is set.
            if (direction.x > 0)
            {
                _animator.SetFloat("Last_Horizontal", 1);
            }
            if (direction.x < 0)
            {
                _animator.SetFloat("Last_Horizontal", -1);
            }
        }

        state = NodeState.RUNNING;
        return state;
    }

}