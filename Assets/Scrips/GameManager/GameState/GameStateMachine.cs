using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{

    public static GameState currentState;
    public GameState spawnPlayerState;
    public GameState playingState;

    public void Init()
    {
        InitState();
        currentState = spawnPlayerState;
        currentState.Enter();
    }

    public void InitState()
    {
        spawnPlayerState = new SpawnPlayerState();
        playingState = new PlayingState();
    }

    public void Update()
    {
        currentState.Update();
    }

    public void ChangeState(GameState _nextState)
    {
        currentState.Exit();
        currentState = _nextState;
        currentState.Enter();
    }

}
