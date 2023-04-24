using System.Collections.Generic;
using BehaviorTree;


public class SlimeBT : Tree
{
    public UnityEngine.Transform[] waypoints;

    public static float speed = 0.5f;
    public static float fovRange = 6f;
    public static float attackRange = 1f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            
            new Sequence(new List<Node>
            {
                new CheckPlayerInFOVRange(transform),
                new TaskGoToTarget(transform),
            }),
            new TaskPatrol(transform, waypoints),
        });

        return root;
    }
}