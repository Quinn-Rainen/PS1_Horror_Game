using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    // Player inventory
    public List<AllItems> _inventoryItems = new List<AllItems>();
    public GameObject keyUI;
    public GameObject redUI;
    public GameObject greenUI;
    public GameObject blueUI;
    
    public GameObject Canvas;
    public GameObject aCombo;
    public GameObject aComboS;

    public bool redAcquired = false;
    public bool greenAcquired = false;
    public bool blueAcquired = false;
    public bool oneTime = false;

    public int keycodeNum;
    public string keycodeString;

    AudioSource i_AudioSource;

    public AllItems itemName;

    void Start()
    {
        i_AudioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        Instance = this;
        keycodeNum = Random.Range(0,1000);
    }

    private void Update()
    {
        if (redAcquired && blueAcquired && greenAcquired && !oneTime)
        {
            oneTime = true;
            aCombo.SetActive(false);
            aComboS.SetActive(true);
            Canvas.GetComponent<ObjectiveUI>().openOverlay();
        }
    }

    public void AddItem(AllItems item)
    {
        if (!_inventoryItems.Contains(item))
        {
            _inventoryItems.Add(item);
            i_AudioSource.Play();
            //AllItems itemName = collider.GetComponent<AllItems>();
            switch (item)
            {
                case AllItems.Key:
                    keyUI.SetActive(true); 
                    break;
                case AllItems.Red1:
                    redAcquired = true;
                    redUI.SetActive(true);
                    break;
                case AllItems.Green2:
                    greenAcquired = true;
                    greenUI.SetActive(true);
                    break;
                case AllItems.Blue3:
                    blueAcquired = true;
                    blueUI.SetActive(true);
                    break;
            }
        }
    }

    public void RemoveItem(AllItems item)
    {
        if (_inventoryItems.Contains(item))
        {
            _inventoryItems.Remove(item);
            switch (item)
            {
                case AllItems.Key:
                    keyUI.SetActive(false); 
                    break;
                case AllItems.Red1:
                    redUI.SetActive(false);
                    break;
                case AllItems.Green2:
                    greenUI.SetActive(false);
                    break;
                case AllItems.Blue3:
                    blueUI.SetActive(false);
                    break;
            }
        }
    }

    public string GetKeycodeStr()
    {
        // answer is a three digit string
        keycodeString = keycodeNum.ToString();
        if (keycodeNum < 10) {
            return "00" + keycodeString;
        } else if (keycodeNum < 100) {
            return "0" + keycodeString;
        } else {
            return keycodeString;
        }
    }

    public int GetKeycodeNum()
    {
        return keycodeNum;
    }

    // All inventory items in game
    public enum AllItems
    {
        Key,
        Red1,
        Green2,
        Blue3
    }

}
