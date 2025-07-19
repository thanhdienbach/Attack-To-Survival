using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAttack : Attack
{

    [Header("Component")]    
    [SerializeField] InputManager inputManager;
    [SerializeField] Animator animator;

    [Header("Attack by staff variable / Combo config")]
    [SerializeField] Queue<string> attackQueue = new Queue<string>();
    [SerializeField] bool isAttacking = false;
    [SerializeField] readonly string[] comboSequence = new string[] { "Combo1", "Combo2", "Combo3", "Combo4" };
    [SerializeField] int currentComboIndex = 0;
    [SerializeField] int maxComboCount = 4;


    public override void Init()
    {
        inputManager = GameManager.instance.GetComponentInChildren<InputManager>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EnqueueAttack();
        }
    }
    void EnqueueAttack()
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

        while(attackQueue.Count > 0)
        {
            string currentAttack = attackQueue.Dequeue();
            animator.Play(currentAttack);
            Debug.Log("Play anim: " +  currentAttack); 

            yield return new WaitForSeconds(0.8f);
        }

        isAttacking = false;
        currentComboIndex = 0;
    }
}
