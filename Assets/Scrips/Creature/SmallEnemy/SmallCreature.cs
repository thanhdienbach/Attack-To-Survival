using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCreature : Creature
{

    [SerializeField] WildStateManager wildStateManager;
    [SerializeField] SmallEnemyMovement smallEnemyMovement;

    private void OnEnable()
    {
        Init();
    }
    public override void Init()
    {
        base.Init();
        wildStateManager = GetComponent<WildStateManager>();
        smallEnemyMovement = GetComponent<SmallEnemyMovement>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (smallEnemyMovement.smallEnemyState == WildState.Potral)
        {
            wildStateManager.Changestate(wildStateManager.wildState_Patrol);
        }
        else if (smallEnemyMovement.smallEnemyState == WildState.Idle)
        {
            wildStateManager.Changestate(wildStateManager.wildState_Idle);
        }
    }

    
}
