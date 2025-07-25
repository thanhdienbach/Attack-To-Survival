using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AnimationControl : MonoBehaviour
{

    [Header("Component")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Animator animator;
    [SerializeField] InputManager inputManager;

    [Header("Idle variable")]
    [SerializeField] int isIdlingHash = Animator.StringToHash("isIdling");
    [SerializeField] int isIdleRotationHash = Animator.StringToHash("isIdleRotation");
    [SerializeField] int rotationSpeedHash = Animator.StringToHash("rotationSpeed");

    [Header("Walk variable")]
    [SerializeField] int isWalkingHash = Animator.StringToHash("isWalking");
    [SerializeField] int walkSpeedXHash = Animator.StringToHash("walkSpeedX");
    [SerializeField] int walkSpeedYHash = Animator.StringToHash("walkSpeedY");
    [SerializeField] int walkVHash = Animator.StringToHash("walkV");

    [Header("Jumb variable")]
    [SerializeField] int isJumpingHash = Animator.StringToHash("isJumping");

    [Header("Attack by staff variable / Combo config")]
    [SerializeField] int isAttackHash = Animator.StringToHash("isAttacking");
    [SerializeField] Queue<string> attackQueue = new Queue<string>();
    public bool isAttacking = false;
    [SerializeField] readonly string[] comboSequence = new string[] { "Combo1", "Combo2", "Combo3", "Combo4" };
    [SerializeField] float[] animationTime = new float[4] { 1.9f, 1.2f, 1.3f, 1.2f };
    [SerializeField] bool isFirstTime;
    [SerializeField] int currentComboIndex = 0;
    [SerializeField] int maxComboCount = 4;
    

    public void Init()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        inputManager = GameManager.instance.inputManager;
    }

    public void CancleAllAnimation()
    {

    }
    public void IdleAnimation()
    {
        animator.SetBool(isIdlingHash, playerMovement.isIdling);
    }
    public void WalkAnimation()
    {
        animator.SetBool(isWalkingHash, playerMovement.isWalking);
        animator.SetFloat(walkSpeedXHash, playerMovement.walkSpeedX);
        animator.SetFloat(walkSpeedYHash, playerMovement.walkSpeedY);
        animator.SetFloat(walkVHash, playerMovement.walkVelocity);
    }
    public void JumpAnimation()
    {
        animator.SetBool(isJumpingHash, playerMovement.isJumping);
    }

    public void EnqueueAttack()
    {
        Debug.Log("Log1");
        if (attackQueue.Count < maxComboCount && inputManager.attack)
        {
            Debug.Log("Log2");
            attackQueue.Enqueue(comboSequence[currentComboIndex]);
            currentComboIndex = (currentComboIndex + 1) % comboSequence.Length;

            if (!isAttacking)
            {
                Debug.Log("Call");
                StartCoroutine(ProcessCombo());
            }
        }
    }
    public void EnQueue()
    {

    }
    public IEnumerator ProcessCombo()
    {
        isAttacking = true;
        animator.SetBool(isAttackHash, isAttacking);
        int animationIndex;

        while (attackQueue.Count > 0)
        {
            Debug.Log(attackQueue.Count);
            string currentAttack = attackQueue.Dequeue();
            animator.Play(currentAttack);
            
            for (int i = 0; i < comboSequence.Length; i++)
            {
                if (currentAttack == comboSequence[i])
                {
                    animationIndex = i;
                    yield return new WaitForSeconds(animationTime[animationIndex]);
                }
            }
        }

        isAttacking = false;
        animator.SetBool(isAttackHash, isAttacking);
        currentComboIndex = 0;
    }
    

}
