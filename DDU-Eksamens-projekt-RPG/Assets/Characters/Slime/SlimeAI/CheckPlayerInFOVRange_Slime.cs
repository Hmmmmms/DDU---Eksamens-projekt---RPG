using BehaviorTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckPlayerInFOVRange_Slime : Node
{
    private static int _playerLayerMask = 1 << 6;

    private Transform _transform;

    public CheckPlayerInFOVRange_Slime(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            Collider2D collider = Physics2D.OverlapCircle(_transform.position, SlimeBT.fovRange, _playerLayerMask);


            if (collider != null)
            {
                //Set target data, to the detected collider in playerLayer
                parent.parent.SetData("target", collider.transform);

                state = NodeState.SUCCESS;
                return state;
            }
            else { parent.parent.SetData("target", null); }


            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;
    }

}
