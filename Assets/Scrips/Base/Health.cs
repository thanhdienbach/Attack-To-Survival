using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float curentHealth;
    public bool attacked;

    public void TakeDame(float _damage)
    {
        curentHealth -= _damage;
        if (!attacked)
        {
            attacked = true;
        }
    }
}
