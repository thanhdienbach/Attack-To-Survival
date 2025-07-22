using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Staff : MonoBehaviour
{
    [SerializeField] float damage = 5;
    [SerializeField] Collider collider;

    private void Start()
    {
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wild"))
        {
            Health health = other.GetComponent<Health>();
            if (health != null && Player.instance.animationControl.isAttacking)
            {
                health.TakeDame(damage);
            }
        }
    }
    
    public void SetColliderTrue()
    {
        collider.enabled = true;
    }
    public void SetColliderFalse()
    {
        collider.enabled = false;
    }
}
