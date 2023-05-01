using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems _itemType;
    [SerializeField] SwitchBehavior _switchBehavior;

    public GameObject PickupPrompt;
    private bool proximityCheck;

    void Start()
    {
        PickupPrompt.SetActive(false);
        proximityCheck = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            //_switchBehavior.DoorLockedStatus();
            PickupPrompt.SetActive(true);
            proximityCheck = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            //_switchBehavior.DoorLockedStatus();
            PickupPrompt.SetActive(false);
             proximityCheck = false;
        }
    }

    void Update()
    {
        if (proximityCheck && Input.GetKeyDown(KeyCode.E))
        {
            InventoryManager.Instance.AddItem(_itemType);
                Destroy(gameObject);
                PickupPrompt.SetActive(false);
        }
    }
}
