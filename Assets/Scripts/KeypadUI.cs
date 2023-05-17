using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadUI : MonoBehaviour
{
    public Text textInput;
    public string answer = "123";

    public GameObject Player;
    //public GameObject keyPad;
    public GameObject keypadDisplay;
    public GameObject door;

    public AudioClip boop;
    public AudioClip boop_fail;
    public AudioClip boop_success;
    public AudioClip boop_clear;

    AudioSource kp_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        // on interaction, renable cursor
        keypadDisplay.SetActive(false);
        kp_AudioSource = GetComponent<AudioSource>();
    }

    public void Number(int num)
    {
        kp_AudioSource.clip = boop;
        kp_AudioSource.Play();
        textInput.text += num.ToString();
    }

    public void Execute()
    {
        if (textInput.text == answer)
        {
            kp_AudioSource.clip = boop_success;
            kp_AudioSource.Play();
            textInput.text = "Accepted";
            door.GetComponent<KeypadDoorBehavior>().unlockDoor();
        }
        else
        {
            kp_AudioSource.clip = boop_fail;
            kp_AudioSource.Play();
            textInput.text = "Incorrect";
        }
    }

    public void Clear()
    {
        kp_AudioSource.clip = boop_clear;
        kp_AudioSource.Play();
        textInput.text = "";
    }

    public void Exit()
    {
        keypadDisplay.SetActive(false);
        // on exit, disable cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        if (textInput.text == "Accepted")
        {
            //unlock door, exit keypad UI
        }

        if(keypadDisplay.activeSelf)
        {
            //enable cursor here
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
