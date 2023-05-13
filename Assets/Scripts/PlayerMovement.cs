using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    AudioSource m_AudioSource;
    public AudioClip footfalls; // normal walking audio
    public AudioClip footfalls_sprinting; // normal walking audio

    public float movementSpeed = 10f;
    public float gravity = -9.81f;
    public float vertVelocity = 0;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool isSprinting = false;
    public float sprintSpeedMult;

    public bool isCrouching = false;
    public float crouchingMultiplier;

    public float standingHeight = 1.8f;
    public float crouchingHeight = 1.25f;

    Vector3 velocity;
    bool isGrounded;
    bool is_moving;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        m_AudioSource = GetComponent<AudioSource>();
        is_moving = false;
        isCrouching = false;
    }


    // Update is called once per frame
    void Update()
    {
        
        //used for gravity and falling as the Character Controller is a different way of implementing moving and doesn't have gravity as a trigger
        //might try later to implement it with a rigid body instead but this supposedly allows us to implement crouching easier so
        
        float horizontal = Input.GetAxis("Horizontal");
        float forward = Input.GetAxis("Vertical");

        // check to see if the player is moving, and set is_moving
        // accordingly
        is_moving = !Mathf.Approximately(horizontal, 0.0f) || !Mathf.Approximately(forward, 0.0f);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = !isCrouching;
        }

        if (Input.GetKey(KeyCode.LeftShift) && isCrouching == false)
        {
            isSprinting = true;
        } else {
            isSprinting = false;
        }

        //calculate the movement then apply it
        Vector3 move = transform.right * horizontal + transform.forward * forward;
        if (isCrouching == true)
        {
            controller.height = crouchingHeight;
            move *= crouchingMultiplier;
        } else {
            controller.height = standingHeight;
        }

        if (isSprinting == true)
        {
            move *= sprintSpeedMult;
        }

        // calculate the effect and apply gravity to player
        velocity.y += gravity * Time.deltaTime;

        controller.Move(move * movementSpeed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }

    void FixedUpdate()
    {
        // check if the player is moving and play audio (footsteps) if they are
        if (is_moving)
        {
            if (isSprinting)
            {
                m_AudioSource.clip = footfalls_sprinting;
                // m_AudioSource.Stop();
            }
            else
            {
                m_AudioSource.clip = footfalls;
                // m_AudioSource.Stop();
            }
            
            if (! m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }
    }


}
