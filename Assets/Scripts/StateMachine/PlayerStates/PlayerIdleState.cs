using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : AStateBehaviour
{
    [SerializeField] private float maxTime = 1.0f;
    private float currentTimer;
    //public Animator animator

    public override bool InitializeState()
    {
        //animator = GetComponent<Animator>();
        return true;
    }

    public override void OnStateStart()
    {
        //animator.SetBool("Idle", true);
        currentTimer = maxTime;
    }

    public override void OnStateUpdate()
    {
        currentTimer -= Time.deltaTime;
        /*
        if (currentTimer <= 0.0f)
        {
            //We can force new state in OnStateUpdate by using:
            AssociatedStateMachine.SetState((int)EPlayerState.MoveForward);
        }
        */
    }

    public override void OnStateEnd()
    {
        //animator.SetBool("Idle", false);
    }

    public override int StateTransitionCondition()
    {
        //Set condition to change state
        if (currentTimer <= 0.0f)
        {
            //Calling new State
            return (int)EPlayerState.MoveForward;
        }

        return (int)EPlayerState.Invalid;
    }
}
