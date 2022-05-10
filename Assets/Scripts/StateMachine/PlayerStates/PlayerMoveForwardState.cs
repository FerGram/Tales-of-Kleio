using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoveForwardState : AStateBehaviour
{
    [SerializeField] private float movingSpeed = 2f;
    [SerializeField] private WayPointsManager wayPointManager = null;
    private int lastWayPoint = 0;
    private NavMeshAgent agent;

    public override bool InitializeState()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
            return false;
        return true;
    }

    public override void OnStateStart()
    {
        agent.speed = movingSpeed;

        //Setting Starting Point
        if (!wayPointManager.IsIndexValid(lastWayPoint))
        {
            lastWayPoint = 0;
        }

        Transform poiTransform = wayPointManager.GetWayPointIndex(lastWayPoint);
        if (poiTransform)
        {
            agent.SetDestination(poiTransform.position);
            lastWayPoint++;
        }
    }

    public override void OnStateUpdate()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!wayPointManager.IsIndexValid(lastWayPoint))
            {
                lastWayPoint = 0;
            }

            Transform poiTransform = wayPointManager.GetWayPointIndex(lastWayPoint);
            if (poiTransform)
            {
                agent.SetDestination(poiTransform.position);
                lastWayPoint++;
            }
        }
    }

    public override void OnStateEnd()
    {

    }

    public override int StateTransitionCondition()
    {
        return (int)EPlayerState.Invalid;
    }
}
