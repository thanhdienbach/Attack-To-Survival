using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{

    public CreatureConfig config;

    public Health health;
    public Stamina stamina;
    public Attack attack;
    public Move move;
    public CreatureID creatureID;


    public virtual void Init()
    {
        GetComponents();
        GetParamater();
    }
    void GetComponents()
    {
        health = GetComponent<Health>();
        stamina = GetComponent<Stamina>();
        attack = GetComponent<Attack>();
        move = GetComponent<Move>();
        move.Init();
        creatureID = GetComponent<CreatureID>();
    }
    void GetParamater()
    {
        health.maxHealth = config.maxHealth;
        health.curentHealth = health.maxHealth;

        stamina.maxStamina = config.maxStamina;
        stamina.currentStamina = stamina.maxStamina;

        attack.damage = config.damage;

        move.moveSpeed = config.moveSpeed;

        creatureID.teamID = config.teamID;
        creatureID.creatureType = config.creatureType;
    }
}
