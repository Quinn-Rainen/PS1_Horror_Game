using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour
{
    //animation
    private Vector3 moveDirection;
    public NavMeshAgent agent;

    // for our actual player
    public Transform player;

    // for the layers, confusing name I know but fuck it
    public LayerMask Ground, Player;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    private Animator animator;
    public bool isMoving = false;
    public bool isAttacking = false;

    private void Awake(){
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update(){
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange,Player);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange,Player);

        if(!playerInAttackRange && !playerInSightRange) Patroling();
        if(playerInSightRange && !playerInAttackRange) ChasePlayer();
        if(playerInAttackRange && playerInSightRange) AttackPlayer();

        isMoving = agent.velocity.magnitude > 0.1f;

        //animator.SetBool("isMoving", isMoving);
        animator.SetBool("isAttacking", isAttacking);
        float speed = agent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
    }

    private void Patroling(){
        if (!walkPointSet) SearchWalkPoint();

        if(walkPointSet){
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //If Walkpoint is reached by AI
        if(distanceToWalkPoint.magnitude < 1f){
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint(){
        //Calcs random points in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, Ground)){
            walkPointSet = true;
        }

    }

    private void ChasePlayer(){
        agent.SetDestination(player.position);
    }

    private void AttackPlayer(){
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked){
            //attack code here
            isAttacking = true;
            //
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack(){
        alreadyAttacked = false;
        isAttacking = false;
        alreadyAttacked = false;
    }


}