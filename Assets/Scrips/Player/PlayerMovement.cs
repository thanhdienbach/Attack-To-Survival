using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEngine;

public class PlayerMovement : Move
{

    [Header("Compoment")]
    [SerializeField] InputManager inputManager;
    [SerializeField] CharacterController playerController;
    [SerializeField] bool isGrounding;

    [Header("Idle variable")]
    public bool isIdling;
    public bool isIdleRotation;
    public float rotationSpeed;

    [Header("Walk variable")]
    [SerializeField] Vector3 direction;
    public bool isWalking;
    public float walkSpeedX;
    public float walkSpeedY;
    public float walkVelocity;

    [Header("Run variable")]
    public bool isRunning;

    [Header("Jump variable")]
    [SerializeField] GameObject groundCheck;
    [SerializeField] float raycashDistance = 0.1f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Vector3 velocity;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] bool isJumping;
    


    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
    }

    public override void Init()
    {
        inputManager = GameManager.instance.GetComponentInChildren<InputManager>();
    }

    public void CheckChangeCondition()
    {
        walkSpeedX = inputManager.horizontalInput;
        walkSpeedY = inputManager.verticalInput;
        rotationSpeed = inputManager.mouseX;

        isIdling = walkSpeedX == 0 && walkSpeedY == 0;
        isIdleRotation = isIdling && rotationSpeed != 0;
        isWalking = walkSpeedX != 0 || walkSpeedY != 0;
        isRunning = isWalking && inputManager.isLeftShiftHold;
    }
    //public void PlayerMoveMent()
    //{
    //    IsGround();

    //    if (isGrounding)
    //    {
    //        if (inputManager.verticalInput != 0 || inputManager.horizontalInput != 0)
    //        {
    //            PlayerWalk();
    //        }
    //        else
    //        {
    //            isWalking = false;
    //        }

    //        if (inputManager.isJump)
    //        {
    //            PlayerJump();
    //        }

    //        PlayerRotation();
    //    }

    //    if (isJumping)
    //    {
    //        isWalking = false;
    //        UnchangeDirectionMove();
    //    }

    //}
    //void PlayerJump()
    //{
    //    if (inputManager.verticalInput >= 0)
    //    {
    //        velocity.y = jumpForce;
    //    }
    //    else
    //    {
    //        velocity.y = jumpForce / 2;
    //    }

    //    if (velocity.y < 0)
    //    {
    //        velocity.y = -1;
    //    }

    //    velocity.y += Physics.gravity.y * Time.deltaTime;

    //    playerController.Move(velocity * Time.deltaTime);
    //}
    //public bool IsGround()
    //{
    //    if (Physics.Raycast(groundCheck.transform.position, Vector3.down, raycashDistance, groundMask))
    //    {
    //        isGrounding = true;
    //        isJumping = false ;
    //    }
    //    else
    //    {
    //        isGrounding = false;
    //        isJumping = true;
    //    }
    //    Debug.DrawRay(groundCheck.transform.position, Vector3.down, Color.green, raycashDistance);
    //    return isGrounding;
    //}
    //void UnchangeDirectionMove()
    //{
    //    playerController.Move(direction * moveSpeed * Time.deltaTime);
    //}
    public void PlayerMove()
    {
        if (inputManager.isLeftShiftHold)
        {
            walkSpeedX = inputManager.horizontalInput * 2;
            walkSpeedY = inputManager.verticalInput * 2;
            direction = (transform.right * walkSpeedX + transform.forward * walkSpeedY);
        }
        else
        {
            walkSpeedX = inputManager.horizontalInput;
            walkSpeedY = inputManager.verticalInput;
            direction = (transform.right * walkSpeedX + transform.forward * walkSpeedY);
        }
        if (walkVelocity <= 2)
        {
            walkVelocity = direction.magnitude;
        }
        else
        {
            walkVelocity = 2f;
        }
        playerController.Move(direction * moveSpeed * Time.deltaTime);
    }
    public void PlayerRotation()
    {
        transform.Rotate(Vector3.up * rotationSpeed);
    }
}
