using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorBehavior : MonoBehaviour
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

    [SerializeField] bool _isDoorLocked;
    [SerializeField] InventoryManager.AllItems _requiredItem;
    
    public GameObject Canvas;
    public GameObject findTheKey;
    public GameObject findTheWay;
    public GameObject findTheWayS;


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

    /*

    

    */

    void Update()
    {
        Vector3 distanceToObject = transform.position - player.transform.position; 
        distanceToObject.y = 0;
        if ((distanceToObject.magnitude <= interactionRadius) && Input.GetKeyDown(KeyCode.E))
        {
            if (_isDoorLocked)
            {
                if (HasRequiredItem(_requiredItem)) 
                {
                    _isDoorLocked = false;
                    findTheWay.SetActive(false);
                    findTheWayS.SetActive(true);
                    Canvas.GetComponent<ObjectiveUI>().openOverlay();
                    // play unlock sound
                } else {
                    // play locked sound                
                    findTheKey.SetActive(true);
                    Canvas.GetComponent<ObjectiveUI>().openOverlay();
                    // potentially trigger objective UI
                }
            } else {
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

    public bool HasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        if (InventoryManager.Instance._inventoryItems.Contains(itemRequired))
        {
            return true;
        } else {
            return false;
        }
    }
}

