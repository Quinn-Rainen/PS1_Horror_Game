using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartUI : MonoBehaviour
{

    [SerializeField] CanvasGroup titleText;
    public GameObject inventoryUI;
    public GameObject Canvas;
    public GameObject titleUI;

    // Update is called once per frame
    void Start()
    {
        inventoryUI.SetActive(false);
        titleUI.SetActive(true);
        showTitle(); 
    }

    public void showTitle()
    {
        titleText.alpha = 1;
        StartCoroutine(fadeOverlay(titleText, 1));
    }

    public IEnumerator fadeOverlay(CanvasGroup o, float f)
    {
        yield return new WaitForSeconds(5);
        while (o.alpha > 0.0f)
        {
            o.alpha -= (Time.deltaTime / f);
            yield return null;
        }
        inventoryUI.SetActive(true);
        Canvas.GetComponent<ObjectiveUI>().openOverlay();
        titleUI.SetActive(false);
        
    }
}
