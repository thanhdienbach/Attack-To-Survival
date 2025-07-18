using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{

    private MyStateMachine stateMachine;

    public PlayerState_Idle playerState_Idle;
    public PlayerState_Walk playerState_Walk;


    public void Init()
    {
        stateMachine = new MyStateMachine();

        playerState_Idle = new PlayerState_Idle(stateMachine);
        playerState_Walk = new PlayerState_Walk(stateMachine);

        ChangeState(playerState_Idle);
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
