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

    [Header("Attack by staff variable / Combo config")]
    [SerializeField] Queue<string> attackQueue = new Queue<string>();
    [SerializeField] bool isAttacking = false;
    [SerializeField] readonly string[] comboSequence = new string[] { "Combo1", "Combo2", "Combo3", "Combo4" };
    [SerializeField] int currentComboIndex = 0;
    [SerializeField] int maxComboCount = 4;
    

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
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
    public void JumpAnimation()
    {
        animator.SetBool(isJumpingHash, playerMovement.isJump);
    }

    public void EnqueueAttack()
    {
        if (attackQueue.Count < maxComboCount)
        {
            attackQueue.Enqueue(comboSequence[currentComboIndex]);
            currentComboIndex = (currentComboIndex + 1) % comboSequence.Length;

            if (!isAttacking)
            {
                StartCoroutine(ProcessCombo());
            }
        }
    }
    IEnumerator ProcessCombo()
    {
        isAttacking = true;

        while (attackQueue.Count > 0)
        {
            string currentAttack = attackQueue.Dequeue();
            animator.Play(currentAttack);
            yield return new WaitForSeconds(0.8f);
        }

        isAttacking = false;
        currentComboIndex = 0;
    }

}
