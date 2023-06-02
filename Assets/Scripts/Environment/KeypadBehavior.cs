using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadBehavior : MonoBehaviour
{
    
    public GameObject player;
    public GameObject keypadDisplay;
    public float interactionRadius = 30f;

    [SerializeField] private Camera cam;

    public GameObject Canvas;
    public GameObject aCombo;
    public GameObject aComboS;

    [SerializeField] private string keypadTag = "Keypad";


    void Update()
    {

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        Vector3 distanceToObject = transform.position - player.transform.position; 
        distanceToObject.y = 0;
        // if (Physics.Raycast(ray, out hit)) {
        //     var selection = hit.transform;
            if ((distanceToObject.magnitude <= interactionRadius) && (Input.GetKeyDown(KeyCode.E))) //&& (selection.CompareTag(keypadTag)))
            {
                if(!aComboS.activeSelf) {
                    aCombo.SetActive(true);
                }
                Canvas.GetComponent<ObjectiveUI>().openOverlay();
                keypadDisplay.SetActive(true);
            } else if ((distanceToObject.magnitude > interactionRadius) && (keypadDisplay.activeSelf)){
                keypadDisplay.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
       // }
        
    }
}