using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{

    public PlayerMovement playerMovement;

    public override void Init()
    {
        playerMovement = GetComponent<PlayerMovement>();
        base.Init();
    }
    public void PlayerSpawned()
    {
        GameManager.Instance.gameStateMachine.ChangeState(GameManager.Instance.gameStateMachine.playingState);
    }
}
