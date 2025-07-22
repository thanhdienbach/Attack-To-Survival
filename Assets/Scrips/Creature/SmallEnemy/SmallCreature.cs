using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCreature : Creature
{

    [SerializeField] WildStateManager wildStateManager;
    [SerializeField] SmallEnemyMovement smallEnemyMovement;
    [SerializeField] SmallCreatureHealth smallCreatureHealth;

    private void OnEnable()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
        wildStateManager = GetComponent<WildStateManager>();
        smallEnemyMovement = GetComponent<SmallEnemyMovement>();
        smallCreatureHealth = GetComponent<SmallCreatureHealth>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (smallCreatureHealth.attacked)
        {
            wildStateManager.Changestate(wildStateManager.wildState_Attack);
        }
        else if (smallEnemyMovement.smallEnemyState == WildState.Potral)
        {
            wildStateManager.Changestate(wildStateManager.wildState_Patrol);
        }
        else if (smallEnemyMovement.smallEnemyState == WildState.Idle)
        {
            wildStateManager.Changestate(wildStateManager.wildState_Idle);
        }
    }

}
