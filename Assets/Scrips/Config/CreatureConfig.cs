using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CreatureConfig", menuName = "Config/Creature")]
public class CreatureConfig : ScriptableObject
{
    public float maxHealth;
    public float maxStamina;
    public float damage;
    public float moveSpeed;
    public TeamID teamID;
    public CreatureType creatureType;

}
