using System.Collections.Generic;
using BehaviorTree;


public class SlimeBT : Tree
{
    public UnityEngine.Transform[] waypoints;

    public static float speed = 0.35f;
    public static float fovRange = 0.6f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckPlayerInFOVRange_Slime(transform),
                new TaskGoToTarget_Slime(transform),
            }),
            new TaskPatrol_Slime(transform, waypoints),
        });

        return root;
    }

    
}