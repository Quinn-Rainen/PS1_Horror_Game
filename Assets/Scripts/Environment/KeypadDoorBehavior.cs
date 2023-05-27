using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadDoorBehavior : MonoBehaviour
{
    public bool _isDoorOpen = false;
    Vector3 _doorOpenPos;

    public AudioSource openDoorSound;
    public AudioSource closeDoorSound;
    private Animator anim;

    public GameObject player;
    public float interactionRadius = 40f;

    [SerializeField] bool _isKPDoorLocked;

    void Start()
    {
        openDoorSound.Stop();
        closeDoorSound.Stop();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 distanceToObject = transform.position - player.transform.position; 
        distanceToObject.y = 0;
        if ((distanceToObject.magnitude <= interactionRadius) && Input.GetKeyDown(KeyCode.E))
        {
            if (!_isKPDoorLocked)
            {
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
    }

    void OpenDoor()
    {
        transform.Rotate(0, -90, 0);
        _isDoorOpen = true;
        //anim.SetTrigger("openTrigger");
        openDoorSound.Play();
    }

    void CloseDoor()
    {
        transform.Rotate(0, 90, 0);
        _isDoorOpen = false;
        //anim.SetTrigger("closeTrigger");
        closeDoorSound.Play();
    }

    public void unlockDoor()
    {
        _isKPDoorLocked = false;
        // play unlock sound
    }
}

