using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{

    [Header("Inputmanaget")]
    [SerializeField] InputManager InputManager;

    [Header("Player")]
    [SerializeField] Player Player;

    [Header("Caculate camera tranform variable")]
    [SerializeField] GameObject playerHead; // Point to caculate camera position
    [SerializeField] Vector3 playerHeadOffset; // Offset position of playerHead
    [Range(0f, 10f)]
    public float playerHeadOffset_y = 2.0f; // Changes hight cameraview with each Gameobject(Creature)

    [Space(10)]
    [SerializeField] GameObject playerLookPoint; // Point to caculate camera position
    [SerializeField] Vector3 playerLookPointOffset; // Offset position of playerLookpoint
    [SerializeField] float playerLookPointOffset_y = -0.25f; // Changes x rotation camera with each Gameobject(Creature)

    [Space(10)]
    [SerializeField] Vector3 direction; // Direction to caculate camera position
    [SerializeField] float minDistance = 2; // Minimum distance from camera and player
    [SerializeField] float maxDistance = 10; // Maximum distance from camera and player
    [Range(1f, 10f)]
    [SerializeField] float distance = 4;  // Current distan from camera and player
    [SerializeField] Vector3 refPosition = Vector3.zero;

    [Header("Player setting")]
    [SerializeField] float mouseScroolSensitivity;
    [SerializeField] float smoothTime; // Max time camera need to follow player


    void Awake()
    {
        mouseScroolSensitivity = 150f;
        smoothTime = 0.05f;
        playerHeadOffset = new Vector3(0f, playerHeadOffset_y, 0f);
        playerLookPointOffset = new Vector3(0f, playerLookPointOffset_y, 0f);
    }

    public void Init()
    {
        InputManager = GameManager.Instance.GetComponentInChildren<InputManager>();

        playerHead = new GameObject("Player head");
        playerHead.transform.position = Player.transform.position + playerHeadOffset;

        playerLookPoint = new GameObject("PlayerLookPoint");
    }

    void LateUpdate()
    {
        FolowPlayer();
    }
    void FolowPlayer()
    {
        CaculateNewPosition();
        transform.position = Vector3.SmoothDamp(transform.position, playerHead.transform.position + direction * distance, ref refPosition, smoothTime);
        transform.LookAt(playerLookPoint.transform.position);
    }
    void CaculateNewPosition()
    {
        playerHead.transform.position = Player.transform.position + playerHeadOffset;

        CaculateLookPointPosition();
        CaculateCameraDistance();

        direction = (playerHead.transform.position - playerLookPoint.transform.position).normalized;
    }
    void CaculateLookPointPosition()
    {
        playerLookPointOffset_y = InputManager.mouseNomalizeDeltaFromCenter.y;
        playerLookPointOffset = new Vector3(0f, playerLookPointOffset_y, 0f);
        playerLookPoint.transform.position = playerHead.transform.position + Player.transform.forward + playerLookPointOffset;
    }
    void CaculateCameraDistance()
    {
        if (distance <= minDistance && InputManager.mouseScrool.y < 0 || distance >= maxDistance && InputManager.mouseScrool.y > 0)
        {
            return;
        }
        else
        {
            distance += InputManager.mouseScrool.y * mouseScroolSensitivity;
        }
        
    }
}
