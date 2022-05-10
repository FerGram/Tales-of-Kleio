using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class StateMachine : MonoBehaviour {
    [SerializeField] private List<AStateBehaviour> stateBehaviours = new List<AStateBehaviour>();

    [SerializeField] private int defaultState = 0;

    private AStateBehaviour currentState = null;

    bool InitializeStates()
    {
        for (int i = 0; i < stateBehaviours.Count; ++i)
        {
            AStateBehaviour stateBehaviour = stateBehaviours[i];
            if (stateBehaviour != null && stateBehaviour.InitializeState())
            {
                stateBehaviour.AssociatedStateMachine = this;
                continue;
            }

            Debug.Log($"StateMachine On {gameObject.name} has failed to initalize the state {stateBehaviours[i]?.GetType().Name}!");
            return false;
        }

        return true;
    }

    void Start()
    {
        if (!InitializeStates())
        {
            // Stop This class from executing
            this.enabled = false;
            return;
        }

        if (stateBehaviours.Count > 0)
        {
            int firstStateIndex;// = (defaultState < stateBehaviours.Count) ? defaultState : 0;
            if (defaultState < stateBehaviours.Count)
            {
                firstStateIndex = defaultState;
            }
            else
            {
                firstStateIndex = 0;
            }

            currentState = stateBehaviours[firstStateIndex];
            currentState.OnStateStart();
        }
        else
        {
            Debug.Log($"StateMachine On {gameObject.name} is has no state behaviours associated with it!");
        }
    }

    void Update()
    {
        currentState.OnStateUpdate();

        int newState = currentState.StateTransitionCondition();
        if (IsValidNewStateIndex(newState))
        {
            currentState.OnStateEnd();
            currentState = stateBehaviours[newState];
            currentState.OnStateStart();
        }
    }

    public bool IsCurrentState(AStateBehaviour stateBehaviour)
    {
        return currentState == stateBehaviour;
    }

    public void SetState(int index)
    {
        if (IsValidNewStateIndex(index))
        {
            currentState.OnStateEnd();
            currentState = stateBehaviours[index];
            currentState.OnStateStart();
        }
    }

    private bool IsValidNewStateIndex(int stateIndex)
    {
        return stateIndex < stateBehaviours.Count && stateIndex >= 0;
    }
}
