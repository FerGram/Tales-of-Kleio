using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExampleState : AStateBehaviour
{
    public override bool InitializeState()
    {
        //Here must get component necessary for starting the state
        return true; //must return true to execute the state.
    }


    public override void OnStateStart()
    {
        //In this function we are going to initialize the components like animator, agent, etc...
        Debug.Log("Hello World");
    }

    public override void OnStateUpdate()
    {
        //Here Goes everything related to the Update function
    }

    public override void OnStateEnd()
    {
        //Here we must end action that started in this state eg.stop animation or audioclip related with this state
    }

    public override int StateTransitionCondition()
    {
        return (int)EPlayerState.Invalid;
    }
}
