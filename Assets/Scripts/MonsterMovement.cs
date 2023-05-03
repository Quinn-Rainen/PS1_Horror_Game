using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{

// for z coordinate makes the monster come towards you
    public float monstDistance = -80.0f;
// start a timer to make the model not block the room.
    private float timer = 0f;
    public float monstSpeed = 20.0f;
    private float speed2 = 3.0f; //just for making the model disapeear up
    bool playerInRange = false;
    private bool hasMoved = false;
    public float verticalDistance = 90f;
    private Vector3 startPosition;

    void Start(){
                startPosition = transform.position;
    }

    Vector3 theTarget;
    void Update(){

        if (playerInRange && !hasMoved)
        {
            Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - monstDistance);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * monstSpeed);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                hasMoved = true;
            }
        }

        // if (Vector3.Distance(transform.position, targetPosition) < 0.1f){
        //     //initially had this in the above if statement but then it could not trigger if someone walks out of collider
            
        //     timer += Time.deltaTime; 
        //     if (timer >= 10f && !hasMoved) 
        //     {
        //         //calculate vertical distance to make monster disappear
        //         targetPosition = transform.position + new Vector3(0, verticalDistance, 0);
        //         transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed2);
                
        //         // Make a check to stop after my arbitrary point so it doesn't get compiler errors
        //         if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        //         {
        //             hasMoved = true;
        //         }
        //     } 
        // }   


    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

}
