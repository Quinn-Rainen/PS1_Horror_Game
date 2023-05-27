using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetRedUI : MonoBehaviour
{
    public GameObject ComboHolder;
    private int redNumber;

    void Start()
    {
        redNumber = ComboHolder.GetComponent<ComboDisplay>().redNum;
        this.GetComponent<Image>().sprite = ComboHolder.GetComponent<ComboDisplay>().redList[redNumber];
    }
}
