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
    public PlayerAttack playerAttack;
    public Staff staff;
    public AnimationControl animationControl;
    public PlayerStateManager stateManager;

    public override void Init()
    {
        base.Init();
        playerMovement = GetComponent<PlayerMovement>();
        animationControl = GetComponent<AnimationControl>();
        playerAttack = GetComponent<PlayerAttack>();
        staff = GetComponentInChildren<Staff>();
        stateManager = GetComponent<PlayerStateManager>();
        stateManager.Init();
    }

    public void ListenAction()
    {
        playerMovement.CheckMoveCondition();

        if (playerMovement.attack)
        {
            stateManager.ChangeState(stateManager.playerState_Attack);
        }
        else if (playerMovement.isJump)
        {
            stateManager.ChangeState(stateManager.playerState_Jump);
        }
        else if (playerMovement.isIdling)
        {
            stateManager.ChangeState(stateManager.playerState_Idle);
        }
        else if (playerMovement.isWalking)
        {
            stateManager.ChangeState(stateManager.playerState_Walk);
        }
    }

    public void SetStaffCanAttack()
    {
        staff.SetColliderTrue();
    }
    public void SetStaffCantAttack()
    {
        staff.SetColliderFalse();
    }
}
