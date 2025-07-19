using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Jump : IState
{

    private MyStateMachine stateMachine;

    public PlayerState_Jump(MyStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public void OnEnter()
    {
        Debug.Log("Jump state: Enter");
        Player.instance.playerMovement.PlayerJump();
        Player.instance.animationControl.JumpAnimation();
    }
    public void OnUpdate()
    {
        
    }
    public void OnExit()
    {
        Debug.Log("Jump state: Exit");
        Player.instance.playerMovement.forced = false;
    }
}
