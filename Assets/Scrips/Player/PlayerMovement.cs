using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : Move
{

    public CharacterController playerController;
    public InputManager InputManager;

    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
    }

    public override void Init()
    {
        InputManager = GameManager.Instance.GetComponentInChildren<InputManager>();
    }

    void Update()
    {
        PlayerMoveMent();
    }

    void PlayerMoveMent()
    {
        PlayerWalk();
        PlayerRotation();
    }
    void PlayerWalk()
    {
        Vector3 direction = (transform.forward * InputManager.verticalInput);
        playerController.Move(direction * moveSpeed * Time.deltaTime);
    }
    void PlayerRotation()
    {
        transform.Rotate(Vector3.up * InputManager.mouseX);
    }
}
