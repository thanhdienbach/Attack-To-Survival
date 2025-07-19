using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SmallEnemyMovement : Move
{

    [Header("Component")]
    [SerializeField] SmallCreature smallCreature;

    [Header("Patrol variable")]
    [SerializeField] Transform paltrolPlace;
    [SerializeField] float paltrolDistance = 20.0f;
    public float randomDistance;
    
    void Start()
    {
        smallCreature = GetComponent<SmallCreature>();
        
        
    }

    void Update()
    {
        StartCoroutine(Patrol());
    }

    IEnumerator Patrol()
    {
        Vector3 destination = RandomMove();
        yield return new WaitForSeconds(5f);
        transform.position = Vector3.Lerp(transform.position, destination, 1);
    }

    void Idle()
    {

    }
    Vector3 RandomMove()
    {
        Vector3 destination = new Vector3();
        if (Vector3.Distance(transform.position, paltrolPlace.position) > paltrolDistance)
        {
            destination = paltrolPlace.position;
        }
        else
        {
            randomDistance = UnityEngine.Random.Range(-10, 10);
            destination = new Vector3(randomDistance, 0, randomDistance);
        }
        return destination;
    }
}
