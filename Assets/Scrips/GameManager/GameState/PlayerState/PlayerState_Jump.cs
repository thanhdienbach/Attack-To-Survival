using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Jump : IState
{

    private MyStateMachine stateMachine;
    private float firstTimes;
    private float firstTimesOfsset = 0.5f;

    public PlayerState_Jump(MyStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public void OnEnter()
    {
        Player.instance.playerMovement.PlayerJump();
        Player.instance.animationControl.JumpAnimation();
        firstTimes = Time.time + firstTimesOfsset;
    }
    public void OnUpdate()
    {
        Player.instance.playerMovement.UnchangeDirectionMove();

        if (Player.instance.playerMovement.isGrounding && Time.time > firstTimes)
        {
            Player.instance.playerMovement.isJumping = false;
        }
        Player.instance.animationControl.JumpAnimation();
    }
    public void OnExit()
    {
        Player.instance.playerMovement.forced = false;
    }
}
