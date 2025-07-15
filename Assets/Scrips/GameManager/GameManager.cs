using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Instance
    public static GameManager Instance;
    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    public GameStateMachine gameStateMachine;
    public Player player;
    public CameraController cameraController;
    public InputManager inputManager;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        gameStateMachine = GetComponentInChildren<GameStateMachine>();
        gameStateMachine.Init();

        inputManager = GetComponentInChildren<InputManager>();

        player.Init();

        cameraController.Init();
    }

    private void Update()
    {
        if (GameStateMachine.currentState == gameStateMachine.spawnPlayerState) 
        {
            return;
        }
        else
        {
            inputManager.ListenInput();
            // player.playerMovement.PlayerMoveMent();
        }
    }
}
