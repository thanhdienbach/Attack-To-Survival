using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class SmallEnemyMovement : Move
{

    [Header("Component")]
    [SerializeField] SmallCreature smallCreature;
    public NavMeshAgent agent;
    public WildState smallEnemyState;
    [SerializeField] Animator animator;

    [Header("Idle variable")]
    public bool isIdle;
    public string idleString = "ChomperIdle";

    [Header("Patrol variable")]
    public bool isPatrol;
    public string isPatrolString = "ChomperWalkForward";
    [SerializeField] float wanderRadius = 20f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        smallEnemyState = WildState.Idle;
    }

    void Update()
    {

    }

    #region Setstate
    public void IsIdle()
    {
        smallEnemyState = WildState.Idle;
        animator.Play(idleString);
    }
    public void IsPotral()
    {
        smallEnemyState = WildState.Potral;
        animator.Play(isPatrolString);
    }
    public void IsAttack()
    {
        smallEnemyState = WildState.Attack;
    }
    public void IsDie()
    {
        smallEnemyState = WildState.Die;
    }
    #endregion

    public void Move()
    {
        Vector3 newDestination = GetRandomNavMeshPosition(transform.position, wanderRadius);
        agent.SetDestination(newDestination);
    }
    Vector3 GetRandomNavMeshPosition(Vector3 center, float radius)
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomDirection += center;
            randomDirection.y = center.y;

            if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, radius, NavMesh.AllAreas))
            {
                return hit.position;
            }
        }
        return center;
    }

    public bool Arrived()
    {
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0)
            {
                return true;
            }
        }
        
        return false;
    }
}
