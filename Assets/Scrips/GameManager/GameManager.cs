using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region instance
    public static GameManager instance;
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
    public CameraController cameraController;
    public GameStateManager gameStateManager;
    public SpawnEnemyManager spawnEnemyManager;


    private void Start()
    {
        Init();
    }

    public void Init()
    {
        inputManager = GetComponentInChildren<InputManager>();

        Player.instance.Init();

        CameraController.instance.Init();

        spawnEnemyManager = GetComponentInChildren<SpawnEnemyManager>();
        spawnEnemyManager.Init();

        gameStateManager = gameObject.AddComponent<GameStateManager>();
        gameStateManager.Init();
    }
}
