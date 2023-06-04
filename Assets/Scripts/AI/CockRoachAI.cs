using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CockRoachAI : MonoBehaviour
{
// Dumbed down version of the AI movement script that just patrols



    public NavMeshAgent agent;
    public Transform player;
    public LayerMask Ground, Player;

    public bool isMoving = false;
    public bool isAttacking = false;
//----------------AI Movement Variables---------------------
    public float patrolSpeed = 2f;

    public float rotationSpeed = 5f;
    private AIState currentState;
    private Vector3 patrolPoint;
    private bool walkPointSet;
    private bool alreadyAttacked;
//----------------------------------------------------------------



    private enum AIState
    {
        Patrol
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
        // potentially make this an adjustable slider in the editor for final version
        float randomZ = Random.Range(-60f, 60f);
        float randomX = Random.Range(-60f, 60f);

        patrolPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        walkPointSet = true;
    }

   

    private void CheckTransitions()
    {
        currentState = AIState.Patrol;
        
    }
}
