using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;



    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //used for gravity and falling as the Character Controller is a different way of implementing moving and doesn't have gravity as a trigger
        //might try later to implement it with a rigid body instead but this supposedly allows us to implement crouching easier so

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


         float horizontal = Input.GetAxis("Horizontal");
         float forward = Input.GetAxis("Vertical");

        //calculate the movement then apply it
        Vector3 move = transform.right * horizontal + transform.forward * forward;
        controller.Move(move * speed * Time.deltaTime);

        // calculate the effect and apply gravity to player
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

}
