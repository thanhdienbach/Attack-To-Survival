using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildState_Patrol : IState
{
    [SerializeField] MyStateMachine stateMachine;
    public SmallEnemyMovement smallEnemyMovement;

    public WildState_Patrol(MyStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public void OnEnter()
    {
        smallEnemyMovement.Move();
    }
    public void OnUpdate()
    {
        if (smallEnemyMovement.Arrived())
        {
            smallEnemyMovement.IsIdle();
        }
    }
    public void OnExit()
    {

    }
}
