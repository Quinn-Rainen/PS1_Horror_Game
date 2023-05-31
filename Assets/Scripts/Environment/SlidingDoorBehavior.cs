using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorBehavior : MonoBehaviour
{
    public bool _isDoorOpen = false;
    Vector3 _doorOpenPos;

    //private Animator anim;

    public GameObject timerPuzzle;

    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Awake()
    {
        //_doorClosedPos = transform.position;

        //_doorOpenPos = new Vector3(transform.position.x + 5f, transform.position.y, transform.position.z);

    }

    /*

    

    */

    void Update()
    {
        
        if (timerPuzzle.GetComponent<Timer>().IsAllLeversActivated())
        {
            if (!_isDoorOpen)
            {
                OpenDoor();
            }  
        }
    }

    void OpenDoor()
    {
        
        transform.position = transform.position + new Vector3 (20f, 0f, 20f);
        _isDoorOpen = true;
        //anim.SetTrigger("openTrigger");
    }

}

