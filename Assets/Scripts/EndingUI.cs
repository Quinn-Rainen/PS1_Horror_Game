using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingUI : MonoBehaviour
{
    public GameObject endingPopup;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            endingPopup.SetActive(true);
        }
    }
}
