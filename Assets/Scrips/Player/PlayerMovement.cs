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

    [Header("Walk variable")]
    [SerializeField] Vector3 direction;

    [Header("Jump variable")]
    [SerializeField] GameObject groundCheck;
    [SerializeField] float raycashDistance = 0.1f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] Vector3 velocity;
    [SerializeField] float jumpForce = 10f;
    


    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
    }

    public override void Init()
    {
        inputManager = GameManager.Instance.GetComponentInChildren<InputManager>();
    }

    void Update()
    {
        PlayerMoveMent();
    }

    public void PlayerMoveMent()
    {
        PlayerJump();
        if (IsGround())
        {
            PlayerWalk();
            PlayerRotation();
        }
        else
        {
            UnchangeDirectionMove();
        }
    }
    void PlayerJump()
    {
        if (IsGround() && velocity.y < 0)
        {
            velocity.y = -1;
        }
        
        if (IsGround() && inputManager.jumb)
        {
            if (inputManager.verticalInput >= 0)
            {
                velocity.y = jumpForce;
            }
            else
            {
                velocity.y =  jumpForce / 2;
            }
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;

        playerController.Move(velocity * Time.deltaTime);
    }
    public bool IsGround()
    {
        return Physics.Raycast(groundCheck.transform.position, Vector3.down, raycashDistance, groundMask);
    }
    void UnchangeDirectionMove()
    {
        playerController.Move(direction * moveSpeed * Time.deltaTime);
    }
    void PlayerWalk()
    {
        direction = (transform.right * inputManager.horizontalInput +  transform.forward * inputManager.verticalInput);
        playerController.Move(direction * moveSpeed * Time.deltaTime);
    }
    void PlayerRotation()
    {
        transform.Rotate(Vector3.up * inputManager.mouseX);
    }
}
