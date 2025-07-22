using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildState_Attack : IState
{
    [SerializeField] MyStateMachine stateMachine;
    public SmallEnemyMovement smallEnemyMovement;

    public WildState_Attack(MyStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public void OnEnter()
    {
        smallEnemyMovement.agent.isStopped = true;
        smallEnemyMovement.IsAttack();
    }
    public void OnUpdate()
    {
        smallEnemyMovement.Attack();
    }
    public void OnExit()
    {

    }
}
