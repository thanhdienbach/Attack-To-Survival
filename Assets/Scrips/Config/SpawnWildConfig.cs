using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SpawnWildConfig", menuName = "Config/SpawnWild")]
public class SpawnWildConfig : ScriptableObject
{
    public GameObject[] wilds;
    public int[] count;
}
