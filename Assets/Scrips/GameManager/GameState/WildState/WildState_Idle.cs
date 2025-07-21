using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildState_Idle : IState
{
    [SerializeField] MyStateMachine stateMachine;
    public SmallEnemyMovement smallEnemyMovement;

    public WildState_Idle(MyStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }
    public WildState_Idle(SmallEnemyMovement _smallEnemyMovement)
    {
        smallEnemyMovement = _smallEnemyMovement;
    }

    public void OnEnter()
    {
        
    }
    public void OnUpdate()
    {
        Debug.Log("Idle");
    }
    public void OnExit()
    {

    }

}
