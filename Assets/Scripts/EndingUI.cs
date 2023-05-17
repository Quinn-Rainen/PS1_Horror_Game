using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingUI : MonoBehaviour
{
    //public GameObject endingPopup;
    public GameObject inventoryUI;
    public GameObject dotUI;
    public AudioSource gameWinSound;
    public GameObject oldDoor;
    public GameObject newDoor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            //endingPopup.SetActive(true);
            inventoryUI.SetActive(false);
            dotUI.SetActive(false);
            gameWinSound.Play();
            oldDoor.SetActive(false);
            newDoor.SetActive(true);
        }
    }
}
