using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject FlashlightLight;
    public bool FlashlightActive = true;

    AudioSource flashlightToggleSound;
    Light Flashlight_emitter;

    // Start is called before the first frame update
    void Start()
    {
        flashlightToggleSound = FlashlightLight.gameObject.GetComponent<AudioSource>();
        Flashlight_emitter = FlashlightLight.gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (! PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.F)){
                flashlightToggleSound.Play();
                if (!FlashlightActive)
                {
                    Flashlight_emitter.intensity = 15; // 15 is the default brightness
                    FlashlightActive = true;
                } 
                else 
                {
                    Flashlight_emitter.intensity = 0; // 0 to turn off flashlight
                    FlashlightActive = false;
                }
            }
        }
    }
}
