using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Move
{

    [Header("Compoment")]
    [SerializeField] InputManager inputManager;
    [SerializeField] CharacterController playerController;
    public bool isGrounding;

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
    [SerializeField] float raycashDistance = 0.5f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Vector3 velocity;
    [SerializeField] float jumpForce = 10f;
    public bool isJump;
    public bool isJumping;
    public bool forced;

    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
    }

    public override void Init()
    {
        inputManager = GameManager.instance.GetComponentInChildren<InputManager>();
    }

    public void CheckGroundAndAddGravity()
    {

        isGrounding = IsGround();

        Gravity();
    }

    public void ChecMoveCondition()
    {
        rotationSpeed = inputManager.mouseX;
        isWalking = isGrounding && inputManager.verticalInput != 0 || inputManager.horizontalInput != 0;
        isIdling = isGrounding && inputManager.verticalInput == 0 || inputManager.horizontalInput == 0;
    }

    void Gravity()
    {
        velocity.y += Physics.gravity.y * Time.deltaTime;
        if (velocity.y < 0 && isGrounding)
        {
            velocity.y = -1;
        }
        playerController.Move(velocity * Time.deltaTime);
    }
    public void PlayerJump()
    {
        if (!forced)
        {
            if (inputManager.verticalInput >= 0)
            {
                velocity.y = jumpForce;
            }
            else
            {
                velocity.y = jumpForce / 2;
            }
            forced = !forced;
        }
        if (isJumping == false)
        {
            isJumping = true;
        }
    }
    public bool IsGround()
    {
        if (Physics.Raycast(groundCheck.transform.position, Vector3.down, raycashDistance, groundMask))
        {
            isGrounding = true;
        }
        else
        {
            isGrounding = false;
        }
        Debug.DrawRay(groundCheck.transform.position, Vector3.down, Color.green, raycashDistance);
        return isGrounding;
    }
    public void UnchangeDirectionMove()
    {
        playerController.Move(direction * moveSpeed * Time.deltaTime);
    }
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
    public void EndedJump()
    {
        isJumping = false;
    }
    public void ResetWalkVariable()
    {
        walkSpeedX = walkSpeedY = walkVelocity = 0;
        isWalking = false;
    }

}
