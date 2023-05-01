using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems _itemType;
    [SerializeField] SwitchBehavior _switchBehavior;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            //_switchBehavior.DoorLockedStatus();
            InventoryManager.Instance.AddItem(_itemType);
            Destroy(gameObject);
        }
    }
}
