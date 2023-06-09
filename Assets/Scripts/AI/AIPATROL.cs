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
    // Dumbed down version of the AI movement script that just patrols
    public NavMeshAgent agent;

    //----------------AI Movement Variables---------------------
    public float patrolSpeed = 6f;
    public float rotationSpeed = 5f;

    private AIState currentState;
    private Vector3 patrolPoint;
    private bool walkPointSet;
    private bool alreadyAttacked;

    private enum AIState
    {
        Patrol
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.Warp(transform.position);
        //Moves Erins model up 
        agent.baseOffset = transform.position.y * 1f;
    }

    private void Start()
    {
        currentState = AIState.Patrol;
        SetNextPatrolPoint();
    }

    private void Update()
    {
        transform.localEulerAngles = Vector3.forward;

        if (currentState == AIState.Patrol && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            StartCoroutine(Patrol());
        }
    }

    private IEnumerator Patrol()
    {
        // Debug.Log("Outer Patrol");

        if (!walkPointSet || Vector3.Distance(transform.position, patrolPoint) < 1f)
        {
            // Debug.Log("Inner Patrol");
            SetNextPatrolPoint();
        }

        agent.speed = patrolSpeed;
        agent.SetDestination(patrolPoint);
        walkPointSet = false; // Reset the walkPointSet flag

        // Wait until the agent reaches the destination
        yield return new WaitUntil(() => agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending);

        // Wait for a delay before setting the next patrol point
        float delay = 2f; // Adjust the delay duration as needed
        yield return new WaitForSeconds(delay);

        // Set the next patrol point
        StartCoroutine(Patrol());
    }

    private void SetNextPatrolPoint()
    {
        // Debug.Log("Inside Set Patrol");

        // potentially make this an adjustable slider in the editor for final version
        float randomZ = Random.Range(-60f, 60f);
        float randomX = Random.Range(-60f, 60f);

        patrolPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        walkPointSet = true;
    }
}