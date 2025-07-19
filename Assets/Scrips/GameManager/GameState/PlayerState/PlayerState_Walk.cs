using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Walk : IState
{

    private MyStateMachine stateMachine;

    public PlayerState_Walk(MyStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public void OnEnter()
    {
        // Mở khóa xoay nhân vật
        // Hũy hooifmaus và stamina
    }
    public void OnUpdate()
    {
        Debug.Log("Walk state: Update");
        Player.instance.playerMovement.PlayerMove();
        Player.instance.playerMovement.PlayerRotation();
        Player.instance.animationControl.WalkAnimation();
    }
    public void OnExit()
    {
        Player.instance.animationControl.WalkAnimation();
    }
}
