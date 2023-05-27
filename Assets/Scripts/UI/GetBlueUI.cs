using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetBlueUI : MonoBehaviour
{
    public GameObject ComboHolder;
    private int blueNumber;

    void Start()
    {
        blueNumber = ComboHolder.GetComponent<ComboDisplay>().blueNum;
        this.GetComponent<Image>().sprite = ComboHolder.GetComponent<ComboDisplay>().blueList[blueNumber];
    }
}
