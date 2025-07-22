using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCreatureHealth : Health
{
    [SerializeField] WildHealthBar healthBar;    
    
    public void Start()
    {
        healthBar = GetComponentInChildren<WildHealthBar>();
        healthBar.Init(curentHealth);
    }

    void Update()
    {
        healthBar.HealthBarUpDate(curentHealth);
        if (curentHealth <= 0)
        {
            OverHealthEvent();
        }
    }
    void OverHealthEvent()
    {
        Debug.Log("OverHealthEvent");
    }
}
