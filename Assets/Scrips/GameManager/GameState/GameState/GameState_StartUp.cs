using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_StartUp : IState
{
    private MyStateMachine stateMachine;

    public GameState_StartUp(MyStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public void OnEnter()
    {
        Debug.Log("Game startup: Enter");
    }
    public void OnUpdate()
    {
        Debug.Log("Game startup: Update");
    }
    public void OnExit()
    {
        Debug.Log("Game startup: Exit");
    }
}
