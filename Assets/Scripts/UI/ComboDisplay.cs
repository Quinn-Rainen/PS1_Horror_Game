using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboDisplay : MonoBehaviour
{
    public Sprite[] redList;
    public Sprite[] greenList;
    public Sprite[] blueList;

    public int redNum;
    public int greenNum;
    public int blueNum;

    void Start()
    {
        GameObject inventory = GameObject.FindGameObjectWithTag("InvMgr");
        int keycodeNumber = inventory.GetComponent<InventoryManager>().GetKeycodeNum();
        redNum = (int) (Mathf.Floor(keycodeNumber / 100));
        greenNum = (int) (Mathf.Floor((keycodeNumber - (redNum * 100)) / 10));
        blueNum = (int) (keycodeNumber - ((redNum * 100) + (greenNum * 10)));
        
    }
}
