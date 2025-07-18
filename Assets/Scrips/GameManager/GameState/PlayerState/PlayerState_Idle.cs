using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Idle : IState
{
    private MyStateMachine stateMachine;

    public PlayerState_Idle(MyStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public void OnEnter()
    {
        // Khóa xoay nhân vật
        // Kích hoạt hồi máu và stamina
        Debug.Log("Player idle: Enter");
    }
    public void OnUpdate()
    {
        Player.instance.animationControl.IdleAnimation();
        Player.instance.playerMovement.PlayerRotation();
    }
    public void OnExit()
    {
        Player.instance.animationControl.IdleAnimation();
    }
}
