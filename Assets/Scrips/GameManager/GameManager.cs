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

    public Player Player;
    public CameraController CameraController;
    public InputManager InputManager;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        Player.Init();
        CameraController.Init();
        InputManager = GetComponentInChildren<InputManager>();
    }
}
