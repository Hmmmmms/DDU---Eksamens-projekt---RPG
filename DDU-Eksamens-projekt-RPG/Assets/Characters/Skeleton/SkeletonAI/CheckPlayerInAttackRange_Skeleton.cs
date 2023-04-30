using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerInAttackRange_Skeleton : Node
{
    private Transform _transform;
    private Animator _animator;

    public CheckPlayerInAttackRange_Skeleton(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        Transform target = (Transform)t;
        if (Vector2.Distance(_transform.position, (target.position - (DamagableCharacter.PlayerOffsetY - DamagableCharacter.SkeletonOffsetY))) <= SkeletonBT.attackRange)
        {

            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }

}
