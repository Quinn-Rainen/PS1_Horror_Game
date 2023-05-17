using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingUI : MonoBehaviour
{
    public GameObject endingPopup;
    public GameObject inventoryUI;
    public GameObject dotUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            endingPopup.SetActive(true);
            inventoryUI.SetActive(false);
            dotUI.SetActive(false);
        }
    }
}
