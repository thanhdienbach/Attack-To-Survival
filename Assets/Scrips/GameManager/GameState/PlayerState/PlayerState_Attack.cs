using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Attack : IState
{
    
    private MyStateMachine stateMachine;
    [SerializeField] bool isFirstTime = true;

    public PlayerState_Attack(MyStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public void OnEnter()
    {
        Player.instance.animationControl.EnqueueAttack();

    }
    public void OnUpdate()
    {
        if (!isFirstTime)
        {
            Player.instance.animationControl.EnqueueAttack();
        }
        else
        {
            isFirstTime = false;
        }
        
    }
    public void OnExit()
    {
        isFirstTime = true;
    }
}
