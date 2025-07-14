using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [Header("Player move input")]
    public float verticalInput;
    public float horizontalInput;
    public float mouseX;

    [Header("Camera move input")]
    [SerializeField] CameraMode cameraMode;
    public Vector2 mouseNomalizeDeltaFromCenter;
    public Vector2 mouseScrool;


    private void Awake()
    {
        cameraMode = CameraMode.BackView_Follow;
    }

    void Update()
    {
        ListenInput();
    }

    void ListenInput()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (cameraMode == CameraMode.BackView_Follow)
            {
                cameraMode = CameraMode.MultiPerspective_Follow;
            }
            else
            {
                cameraMode = CameraMode.BackView_Follow;
            }
        }
        if (cameraMode == CameraMode.BackView_Follow)
        {
            PlayerMoveInput_BackFollowMode();
            CameraMoveInput_BackFollowMode();
        }
        
    }
    void PlayerMoveInput_BackFollowMode()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        mouseX = Input.GetAxis("Mouse X");
    }
    void CameraMoveInput_BackFollowMode()
    {
        mouseNomalizeDeltaFromCenter = new Vector2( (Input.mousePosition.x - Screen.width /2) / (Screen.width / 2), (Input.mousePosition.y - Screen.height / 2) / (Screen.height / 2));
        mouseScrool = Input.mouseScrollDelta * Time.deltaTime;
    }
    void ChangeCameraMode(CameraMode _cameraMode)
    {
        cameraMode = _cameraMode;
    }
}
