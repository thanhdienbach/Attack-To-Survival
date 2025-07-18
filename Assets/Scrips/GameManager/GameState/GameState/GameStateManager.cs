using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private MyStateMachine stateMachine;

    public GameState_StartUp gameState_Startup;
    public GameState_Playing gameState_Playing;


    public void Init()
    {
        stateMachine = new MyStateMachine();

        gameState_Startup = new GameState_StartUp(stateMachine);
        gameState_Playing = new GameState_Playing(stateMachine);
        
        ChangeState(gameState_Playing);
    }

    private void Update()
    {
        stateMachine.UpDate();
    }

    public void ChangeState(IState _nextState)
    {
        stateMachine.ChangeState(_nextState);
    }
}
