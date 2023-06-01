using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIPATROL : MonoBehaviour
{
// Dumbed down version of the AI movement script that just patrols



    public NavMeshAgent agent;
    public Transform player;
    public LayerMask Ground, Player;
    private Animator animator;

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


    // audio sources
    [SerializeField] private AudioClip[] monster_ambient_clips;
    private int clip_ind;

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
        animator = GetComponent<Animator>();

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
        float speed2 = agent.velocity.magnitude;
        animator.SetFloat("Speed", speed2);
        agent.SetDestination(patrolPoint);
        // Debug.Log(isAttacking);
    }

    private void SetNextPatrolPoint()
    {
        // potentially make this an adjustable slider in the editor for final version
        float randomZ = Random.Range(-20f, 20f);
        float randomX = Random.Range(-20f, 20f);

        patrolPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        walkPointSet = true;
    }

   

    private void CheckTransitions()
    {
        Vector3 aiPosition = agent.nextPosition;
        Vector3 playerPosition = player.position;
        currentState = AIState.Patrol;
        
    }

}
