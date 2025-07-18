using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AnimationControl : MonoBehaviour
{

    [Header("Component")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Animator animator;

    [Header("Idle variable")]
    [SerializeField] int isIdlingHash = Animator.StringToHash("isIdling");
    [SerializeField] int isIdleRotationHash = Animator.StringToHash("isIdleRotation");
    [SerializeField] int rotationSpeedHash = Animator.StringToHash("rotationSpeed");

    [Header("Walk variable")]
    [SerializeField] int isWalkingHash = Animator.StringToHash("isWalking");
    [SerializeField] int walkSpeedXHash = Animator.StringToHash("walkSpeedX");
    [SerializeField] int walkSpeedYHash = Animator.StringToHash("walkSpeedY");
    [SerializeField] int walkVelocityHash = Animator.StringToHash("walkVelocity");
    [SerializeField] int walkVHash = Animator.StringToHash("walkV");

    [Header("Jumb variable")]
    [SerializeField] int isJumpingHash = Animator.StringToHash("isJumping");

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    
    void LateUpdate()
    {
        // WalkAnimation();
    }

    public void IdleAnimation()
    {
        animator.SetBool(isIdlingHash, playerMovement.isIdling);
        //animator.SetBool(isIdleRotationHash, playerMovement.isIdleRotation);
        //animator.SetFloat(rotationSpeedHash, playerMovement.rotationSpeed);
    }
    public void WalkAnimation()
    {
        animator.SetBool(isWalkingHash, playerMovement.isWalking);
        animator.SetFloat(walkSpeedXHash, playerMovement.walkSpeedX);
        animator.SetFloat(walkSpeedYHash, playerMovement.walkSpeedY);
        // animator.SetFloat(walkVelocityHash, playerMovement.walkVelocity);
        animator.SetFloat(walkVHash, playerMovement.walkVelocity);
    }

}
