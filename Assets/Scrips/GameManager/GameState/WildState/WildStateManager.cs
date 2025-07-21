using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildStateManager : MonoBehaviour
{
    [SerializeField] MyStateMachine stateMachine;
    public SmallEnemyMovement smallEnemyMovement;

    public WildState_Idle wildState_Idle;
    public WildState_Patrol wildState_Patrol;
    public WildState_Attack wildState_Attack;
    private void Start()
    {
        stateMachine = new MyStateMachine();

        wildState_Idle = new WildState_Idle(stateMachine);
        wildState_Patrol = new WildState_Patrol(stateMachine);
        wildState_Attack = new WildState_Attack(stateMachine);

        smallEnemyMovement = GetComponent<SmallEnemyMovement>();

        wildState_Idle.smallEnemyMovement = wildState_Patrol.smallEnemyMovement = wildState_Attack.smallEnemyMovement =  smallEnemyMovement;

        stateMachine.ChangeState(wildState_Idle);
    }

    private void Update()
    {
        stateMachine.UpDate();
    }

    public void Changestate(IState _nextState)
    {
        stateMachine.ChangeState(_nextState);
    }
}

