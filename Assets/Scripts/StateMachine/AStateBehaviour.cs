using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This has to be abstract due to having a base class for states.
// Unity does not serialize anything related to interfaces
public abstract class AStateBehaviour : MonoBehaviour {
    public StateMachine AssociatedStateMachine { get; set; }
    public virtual bool InitializeState() { return true; }
    public virtual void OnStateStart() { }
    public virtual void OnStateUpdate() { }
    public virtual void OnStateEnd() { }
    public virtual int StateTransitionCondition() { return 0; }
}
