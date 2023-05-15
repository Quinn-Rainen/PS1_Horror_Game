using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveUI : MonoBehaviour
{

    [SerializeField] CanvasGroup objectiveOverlay;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)){
            openOverlay();
        }  
    }

    public void openOverlay()
    {
        objectiveOverlay.alpha = 1;
        StartCoroutine(fadeOverlay(objectiveOverlay, 1));
    }

    public IEnumerator fadeOverlay(CanvasGroup o, float f)
    {
        yield return new WaitForSeconds(4);
        while (o.alpha > 0.0f)
        {
            o.alpha -= (Time.deltaTime / f);
            yield return null;
        }
    }
}
