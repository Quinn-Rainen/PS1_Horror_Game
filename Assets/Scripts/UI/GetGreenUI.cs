using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetGreenUI : MonoBehaviour
{
    public GameObject ComboHolder;
    private int greenNum;

    void Start()
    {
        greenNum = ComboHolder.GetComponent<ComboDisplay>().greenNum;
        this.GetComponent<Image>().sprite = ComboHolder.GetComponent<ComboDisplay>().greenList[greenNum];
    }
}
