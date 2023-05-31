using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingUIScript : MonoBehaviour
{
    public GameObject endingPopup;
    public GameObject inventoryUI;
    public GameObject dotUI;
    //public AudioSource gameWinSound;
    public GameObject oldDoor;
    public GameObject newDoor;
    [SerializeField] CanvasGroup endingText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            endingPopup.SetActive(true);
            inventoryUI.SetActive(false);
            dotUI.SetActive(false);
            //gameWinSound.Play();
            oldDoor.SetActive(false);
            newDoor.SetActive(true);
            showEndCard();

        }
    }

    public void showEndCard()
    {
        endingText.alpha = 0.01f;
        StartCoroutine(fadeOverlay(endingText, 1));
    }

    public IEnumerator fadeOverlay(CanvasGroup o, float f)
    {
        
        while (o.alpha < 1.0f)
        {
            o.alpha += (Time.deltaTime / f);
            yield return null;
        }
        yield return new WaitForSeconds(5);
        endingPopup.SetActive(false);
        ScenesManager.Instance.LoadNextScene();
        
    }
}
