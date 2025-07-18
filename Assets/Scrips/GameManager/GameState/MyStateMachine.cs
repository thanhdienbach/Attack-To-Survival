using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyStateMachine
{
    private IState currentState;

    public void UpDate()
    {
        currentState.OnUpdate();
    }

    public void ChangeState(IState _newState)
    {
        if (currentState == _newState) return;
        currentState?.OnExit();
        currentState = _newState;
        currentState.OnEnter();
    }
}
