using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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

    public InputManager inputManager;
    public PlayerMovement playerMovement;
    public PlayerAttack playerAttack;
    public Staff staff;
    public AnimationControl animationControl;
    public PlayerStateManager stateManager;

    public override void Init()
    {
        base.Init();
        inputManager = GameManager.instance.inputManager;
        stateManager = GetComponent<PlayerStateManager>();
        stateManager.Init();
        playerMovement = GetComponent<PlayerMovement>();
        animationControl = GetComponent<AnimationControl>();
        animationControl.Init();
        playerAttack = GetComponent<PlayerAttack>();
        staff = GetComponentInChildren<Staff>();
    }

    public void ListenAction()
    {
        playerMovement.CheckGroundAndAddGravity();

        if (inputManager.attack && !playerMovement.isJumping)
        {
            stateManager.ChangeState(stateManager.playerState_Attack);
        }
        else if (inputManager.isJump && !animationControl.isAttacking)
        {
            stateManager.ChangeState(stateManager.playerState_Jump);
        }

        if (playerMovement.isGrounding)
        {
            playerMovement.ChecMoveCondition();
        }
        if (playerMovement.isJumping || animationControl.isAttacking)
        {
            return;
        }

        if (playerMovement.isWalking)
        {
            stateManager.ChangeState(stateManager.playerState_Walk);
        }
        else if (playerMovement.isIdling)
        {
            stateManager.ChangeState(stateManager.playerState_Idle);
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
