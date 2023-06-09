using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehavior : MonoBehaviour
{
    [SerializeField] DoorBehavior _doorBehavior;
    [SerializeField] bool _isDoorLocked;
    [SerializeField] bool _isDoorOpenSwitch;
    [SerializeField] bool _isDoorCloseSwitch;

    float _switchSizeY;
    Vector3 _switchUpPos;
    Vector3 _switchDownPos;
    float _switchSpeed = 1f;
    float _switchDelay = 0.2f;
    bool _isPressingSwitch = false;

    [SerializeField] InventoryManager.AllItems _requiredItem;

    public GameObject OpenPrompt;
    public GameObject LockedPrompt;
    private bool proximityCheck;

    //bool _isDoorLocked = true;

    void Awake()
    {
        _switchSizeY = transform.localScale.y / 2;
        _switchUpPos = transform.position;
        _switchDownPos = new Vector3(transform.position.x, transform.position.y - _switchSizeY, transform.position.x);
    }

    void Update()
    {
        // can recycle switches as proximity triggers for doors, if we don't end up using moving switches
        if (_isPressingSwitch)
        {
            MoveSwitchDown();
        }
        else if (!_isPressingSwitch)
        {
            MoveSwitchUp();
        }
        if (proximityCheck && Input.GetKeyDown(KeyCode.E))
        {
            _isPressingSwitch = !_isPressingSwitch;
            OpenPrompt.SetActive(false);
            if (_isDoorLocked) {
                if (HasRequiredItem(_requiredItem))
                {
                    if (_isDoorOpenSwitch && !_doorBehavior._isDoorOpen)
                    {
                        _doorBehavior._isDoorOpen = !_doorBehavior._isDoorOpen;
                    } else if (_isDoorCloseSwitch && _doorBehavior._isDoorOpen)
                    {
                        _doorBehavior._isDoorOpen = !_doorBehavior._isDoorOpen;
                    }
                } else {
                    LockedPrompt.SetActive(true);
                }
            } else {
                if (_isDoorOpenSwitch && !_doorBehavior._isDoorOpen)
                    {
                        _doorBehavior._isDoorOpen = !_doorBehavior._isDoorOpen;
                    } else if (_isDoorCloseSwitch && _doorBehavior._isDoorOpen)
                    {
                        _doorBehavior._isDoorOpen = !_doorBehavior._isDoorOpen;
                    }
            }
        }
    }

    void MoveSwitchDown()
    {
        if (transform.position != _switchDownPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _switchDownPos, _switchSpeed * Time.deltaTime);
        }
    }

    void MoveSwitchUp()
    {
        if (transform.position != _switchUpPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _switchUpPos, _switchSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            //_isPressingSwitch = !_isPressingSwitch;
            OpenPrompt.SetActive(true);
            proximityCheck = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        OpenPrompt.SetActive(false);
        LockedPrompt.SetActive(false);
        proximityCheck = false;
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(SwitchUpDelay(_switchDelay));
        }
    }

    IEnumerator SwitchUpDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _isPressingSwitch = false;
    }

    //public void DoorLockedStatus() {_isDoorLocked = !_isDoorLocked;}

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
