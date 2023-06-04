using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public bool _isDoorOpen = false;
    //Vector3 _doorClosedPos;
    Vector3 _doorOpenPos;
    //float _doorSpeed = 10;

    public AudioSource openDoorSound;
    public AudioSource closeDoorSound;
    private Animator anim;

    public GameObject player;
    public float interactionRadius = 40f;

    void Start()
    {
        openDoorSound.Stop();
        closeDoorSound.Stop();
        anim = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Awake()
    {
        //_doorClosedPos = transform.position;


        //_doorOpenPos = new Vector3(transform.position.x + 5f, transform.position.y, transform.position.z);

    }


    void Update()
    {
        Vector3 distanceToObject = transform.position - player.transform.position; 
        distanceToObject.y = 0;
        if ((distanceToObject.magnitude <= interactionRadius) && Input.GetKeyDown(KeyCode.E))
        {
            //anim.SetBool("isE", true);

            if (!_isDoorOpen)
            {
                OpenDoor();
            } 
            else if (_isDoorOpen)
            {
                CloseDoor();
            }   
        }
    }

    void OpenDoor()
    {
        //transform.Rotate(0, -90, 0);
        _isDoorOpen = true;
        anim.SetBool("isOpen", true);
        openDoorSound.Play();
    }

    void CloseDoor()
    {

        //transform.Rotate(0, 90, 0);
        _isDoorOpen = false;
        anim.SetBool("isOpen", false);
        //anim.SetTrigger("closeTrigger");
        closeDoorSound.Play();
    }
}

