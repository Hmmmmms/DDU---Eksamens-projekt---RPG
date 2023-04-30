using System.Collections.Generic;
using BehaviorTree;


public class SkeletonBT : Tree
{
    public UnityEngine.Transform[] waypoints;

    public static float speed = 0.35f;
    public static float fovRange = 0.6f;
    public static float attackRange = 0.35f;

    

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckPlayerInAttackRange_Skeleton(transform),
                new TaskAttack_Skeleton(transform),
            }),
            new Sequence(new List<Node>
            {
                new CheckPlayerInFOVRange_Skeleton(transform),
                new TaskGoToTarget_Skeleton(transform),
            }),
            new TaskPatrol_Skeleton(transform, waypoints),
        });

        return root;
    }

    
}