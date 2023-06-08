using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
Research Sources:
https://learn.unity.com/tutorial/enumerations#
https://www.youtube.com/watch?v=UjkSFoLxesw
https://www.youtube.com/watch?v=atCOd4o7tG4


OUTDATED SCRIPT FOR STORING PURPOSES
 */
public class AIPATROL : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask Ground, Player;
    //private Animator animator;

    public bool isMoving = false;
    public bool isAttacking = false;
//----------------AI Movement Variables---------------------
    public float sightRange, attackRange;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float rotationSpeed = 5f;
    private AIState currentState;
    private Vector3 patrolPoint;
    private bool walkPointSet;
//----------------------------------------------------------------


    // audio sources

    private enum AIState
    {
        Patrol,Chase,Attack
    }


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.Warp(transform.position);
        //Moves Erins model up 
        agent.baseOffset = transform.position.y * .04f;

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
            // case AIState.Chase:
            //     Chase();
            //     break;
            // case AIState.Attack:
            //     Attack();
            //     break;
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
        // float speed2 = agent.velocity.magnitude;
        // animator.SetFloat("Speed", speed2);
        agent.SetDestination(patrolPoint);
        // Debug.Log(isAttacking);
    }

    private void SetNextPatrolPoint()
    {
        float randomZ = Random.Range(-20f, 20f);
        float randomX = Random.Range(-20f, 20f);

        patrolPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        walkPointSet = true;
    }

    // private void Chase()
    // {

    //     //Debug.Log("CHASING");

    //     agent.speed = chaseSpeed;

    //     // Calculate the direction from the AI to the player
    //     Vector3 chaseDirection = player.position - transform.position;

    //     Vector3 targetPosition = transform.position + chaseDirection;

    //     agent.SetDestination(targetPosition);

    //     Quaternion targetRotation = Quaternion.LookRotation(chaseDirection);
    //     transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    // }

    // private void Attack()
    // {
    //     //Debug.Log("Attacking Now");
    //     agent.SetDestination(transform.position);

    //     Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
    //     transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        

    //     if (!alreadyAttacked)
    //     {
    //         // Future Implementaion of the Jumpscare  code here
    //         // isAttacking = true;
    //         // animator.SetBool("isAttacking", isAttacking);
    //         alreadyAttacked = true;
    //         Invoke(nameof(ResetAttack), timeBetweenAttacks);
    //     }
    // }

    private void ResetAttack()
    {
        Debug.Log("RESETATTACK");

        // isAttacking = false;
        currentState = AIState.Patrol; 
    }

    private void CheckTransitions()
    {
        Vector3 aiPosition = agent.nextPosition;
        Vector3 playerPosition = player.position;

        float distanceToPlayer = (playerPosition - aiPosition).magnitude;

        //Debug.Log("Distance: " + distanceToPlayer);
        if (distanceToPlayer <= attackRange && IsFacingPlayer())
        {
            // Player within attack range
            currentState = AIState.Attack;
        }
        else if (distanceToPlayer > attackRange && distanceToPlayer <= sightRange)
        {
            // Player within sight range but outside attack range
            currentState = AIState.Chase;
        }
        else
        {
            currentState = AIState.Patrol;
        }
    }


    private bool IsFacingPlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float angle = Vector3.Angle(transform.forward, directionToPlayer);
        return angle < 60f;
    }
}