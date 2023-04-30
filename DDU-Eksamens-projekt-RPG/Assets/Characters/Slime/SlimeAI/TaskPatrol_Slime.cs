using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using System.Net.Sockets;

public class TaskPatrol_Slime : Node
{
    private Transform _transform;
    private Animator _animator;
    private Transform[] _waypoints;
    private Rigidbody2D _rb;

    private int _currentWaypointIndex = 0;

    private float _waitTime = 1f; // in seconds
    private float _waitCounter = 0f;
    private bool _waiting = false;

    private Vector2 direction = new Vector2(0, 0);

    public TaskPatrol_Slime(Transform transform, Transform[] waypoints)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
        _waypoints = waypoints;
        _rb = transform.GetComponent<Rigidbody2D>();
    }

    public override NodeState Evaluate()
    {
        if (_waiting)
        {
            _waitCounter += Time.deltaTime;
            if (_waitCounter >= _waitTime)
            {
                _waiting = false;
                _animator.SetBool("isMoving", true);
            }
        }
        else
        {
            Transform wp = _waypoints[_currentWaypointIndex];
            if (Vector2.Distance(_transform.position, wp.position) < 0.01f)
            {
                _transform.position = wp.position;
                _waitCounter = 0f;
                _waiting = true;

                _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
                _animator.SetBool("isMoving", false);
            }
            else
            {
                _transform.position = Vector2.MoveTowards(_transform.position, wp.position, SlimeBT.speed * Time.deltaTime);
                _animator.SetBool("isMoving", true);

                //Decide the direction the Skeleton is moving
                direction = (wp.position - _transform.position).normalized;

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
        }


        state = NodeState.RUNNING;
        return state;
    }

}