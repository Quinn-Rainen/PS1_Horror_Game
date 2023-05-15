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

    // Start is called before the first frame update
    void Start()
    {
        // on interaction, renable cursor
        keypadDisplay.SetActive(false);
    }

    public void Number(int num)
    {
        textInput.text += num.ToString();
    }

    public void Execute()
    {
        if (textInput.text == answer)
        {
            textInput.text = "Accepted";
            door.GetComponent<KeypadDoorBehavior>().unlockDoor();
        }
        else
        {
            textInput.text = "Incorrect";
        }
    }

    public void Clear()
    {
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
