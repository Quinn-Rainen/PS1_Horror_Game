using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartUI : MonoBehaviour
{

    [SerializeField] CanvasGroup titleUI;
    public GameObject inventoryUI;
    public GameObject Canvas;

    // Update is called once per frame
    void Start()
    {
        inventoryUI.SetActive(false);
        showTitle(); 
    }

    public void showTitle()
    {
        titleUI.alpha = 1;
        StartCoroutine(fadeOverlay(titleUI, 1));
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
    }
}
