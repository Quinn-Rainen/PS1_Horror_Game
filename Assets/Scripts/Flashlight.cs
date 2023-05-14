using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject FlashlightLight;
    private bool FlashlightActive = true;
    // Start is called before the first frame update
    void Start()
    {
        FlashlightLight.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.F)){
            if (!FlashlightActive){
                FlashlightLight.gameObject.SetActive(true);
                FlashlightActive = true;
            } else {
                FlashlightLight.gameObject.SetActive(false);
                FlashlightActive = false;
            }
        }
    }
}
