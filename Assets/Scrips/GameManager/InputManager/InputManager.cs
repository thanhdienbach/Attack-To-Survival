using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [Header("Camera mode")]
    public CameraMode cameraMode;

    [Header("Player move input")]
    public float verticalInput;
    public float horizontalInput;
    public float mouseX;
    public bool jumb;

    [Header("Camera move input")]
    public Vector2 mouseNomalizeDeltaFromCenter;
    public Vector2 mouseScrool;


    private void Awake()
    {
        cameraMode = CameraMode.BackView_Follow;
    }

    public void ListenInput()
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
        else if (cameraMode == CameraMode.MultiPerspective_Follow)
        {
            PlayerMoveInput_MultiPerspectiveFollowMode();
            CameraMoveInput_MultiPerspectiveFollowMode();
        }
    }
    void PlayerMoveInput_BackFollowMode()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        mouseX = Input.GetAxis("Mouse X");
        jumb = Input.GetKeyDown(KeyCode.Space);
    }
    void PlayerMoveInput_MultiPerspectiveFollowMode()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }
    void CameraMoveInput_BackFollowMode()
    {
        mouseNomalizeDeltaFromCenter = new Vector2( (Input.mousePosition.x - Screen.width /2) / (Screen.width / 2), (Input.mousePosition.y - Screen.height / 2) / (Screen.height / 2));
        mouseScrool = Input.mouseScrollDelta * Time.deltaTime;
    }
    void CameraMoveInput_MultiPerspectiveFollowMode()
    {

    }
}
