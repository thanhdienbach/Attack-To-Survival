using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameState_Playing : IState
{

    private MyStateMachine stateMachine;

    public GameState_Playing(MyStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public void OnEnter()
    {
        Debug.Log("Game playing: Enter");
        GameManager.instance.spawnEnemyManager.SpawnWild();
    }
    public void OnUpdate()
    {
        Debug.Log("Game playing: Update");
        GameManager.instance.inputManager.ListenInput();
        Player.instance.ListenAction();
    }
    public void OnExit()
    {
        Debug.Log("Game playing: Exit");
    }

}
