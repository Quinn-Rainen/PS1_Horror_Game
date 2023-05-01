using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    // Player inventory
    public List<AllItems> _inventoryItems = new List<AllItems>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(AllItems item)
    {
        if (!_inventoryItems.Contains(item))
        {
            _inventoryItems.Add(item);
        }
    }

    public void RemoveItem(AllItems item)
    {
        if (_inventoryItems.Contains(item))
        {
            _inventoryItems.Remove(item);
        }
    }

    // All inventory items in game
    public enum AllItems
    {
        Key
    }
}
