using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
Research Sources:
https://learn.unity.com/tutorial/enumerations#

 */
public class AIScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask Ground, Player;
    public float sightRange, attackRange;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float rotationSpeed = 5f;

    private enum AIState
    {
        Patrol,
        Chase,
        Attack
    }

    private AIState currentState;
    private Vector3 patrolPoint;
    private bool walkPointSet;
    private bool alreadyAttacked;
    private float timeBetweenAttacks = 2f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        currentState = AIState.Patrol;
        SetNextPatrolPoint();
    }

    private void Update()
    {
        switch (currentState)
        {
            case AIState.Patrol:
                Patrol();
                break;
            case AIState.Chase:
                Chase();
                break;
            case AIState.Attack:
                Attack();
                break;
        }

        CheckTransitions();
    }

    private void Patrol()
    {
        if (!walkPointSet || Vector3.Distance(transform.position, patrolPoint) < 1f)
        {
            SetNextPatrolPoint();
        }

        agent.speed = patrolSpeed;
        agent.SetDestination(patrolPoint);
    }

    private void SetNextPatrolPoint()
    {
        float randomZ = Random.Range(-20f, 20f);
        float randomX = Random.Range(-20f, 20f);

        patrolPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        walkPointSet = true;
    }

    private void Chase()
    {
        Debug.Log("CHASING");

        agent.speed = chaseSpeed;

        // Calculate the direction from the AI to the player
        Vector3 chaseDirection = player.position - transform.position;

        // Calculate the target position by moving towards the player
        Vector3 targetPosition = transform.position + chaseDirection;

        agent.SetDestination(targetPosition);

        Quaternion targetRotation = Quaternion.LookRotation(chaseDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void Attack()
    {
        Debug.Log("Attacking Now");
        agent.SetDestination(transform.position);

        Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (!alreadyAttacked)
        {
            // Attack code here
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        currentState = AIState.Patrol; // Reset to the patrol state
    }
    private void CheckTransitions()
    {
        Vector3 aiPosition = agent.nextPosition;
        Vector3 playerPosition = player.position;

        float distanceToPlayer = (playerPosition - aiPosition).magnitude;

        Debug.Log("Distance: " + distanceToPlayer);
        if (distanceToPlayer <= attackRange && IsFacingPlayer())
        {
            // Player within attack range and AI is facing the player
            currentState = AIState.Attack;
        }
        else if (distanceToPlayer > attackRange && distanceToPlayer <= sightRange)
        {
            // Player within sight range but outside attack range
            currentState = AIState.Chase;
        }
        else
        {
            // Player not in sight range, go back to patrolling
            currentState = AIState.Patrol;
        }
    }


    private bool IsFacingPlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float angle = Vector3.Angle(transform.forward, directionToPlayer);
        return angle < 60f; // Adjust the angle as needed
    }
}