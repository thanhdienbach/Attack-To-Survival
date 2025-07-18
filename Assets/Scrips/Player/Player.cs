using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Player : Creature
{

    #region instance
    public static Player instance;
    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void OnDisable()
    {
        instance = null;
    }
    #endregion

    public PlayerMovement playerMovement;
    public AnimationControl animationControl;
    public PlayerStateManager stateManager;

    public override void Init()
    {
        base.Init();
        playerMovement = GetComponent<PlayerMovement>();
        animationControl = GetComponent<AnimationControl>();
        stateManager = GetComponent<PlayerStateManager>();
        stateManager.Init();
    }

    public void ListenAction()
    {
        playerMovement.CheckChangeCondition();

        if (playerMovement.isIdling) // Todo: Change condition to isIdle
        {
            stateManager.ChangeState(stateManager.playerState_Idle);
        }
        if (playerMovement.isWalking)
        {
            stateManager.ChangeState(stateManager.playerState_Walk);
        }
    }
}
