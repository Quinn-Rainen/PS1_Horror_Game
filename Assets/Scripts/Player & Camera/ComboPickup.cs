using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ComboPickup : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems _itemType;
    //[SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Camera cam;
    
    public GameObject player;
    public float interactionRadius = 30f;

    //public GameObject Canvas;
    //public GameObject findTheKey;
    //public GameObject findTheKeyS;


    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        Vector3 distanceToObject = transform.position - player.transform.position; 
        distanceToObject.y = 0;
        // if (Physics.Raycast(ray, out hit)) {
        //     var selection = hit.transform;
            if ((distanceToObject.magnitude <= interactionRadius) && (Input.GetKeyDown(KeyCode.E))) //&& (selection.CompareTag(selectableTag)))
            {
                InventoryManager.Instance.AddItem(_itemType);
                Destroy(gameObject);
                //findTheKey.SetActive(false);
                //findTheKeyS.SetActive(true);
                //Canvas.GetComponent<ObjectiveUI>().openOverlay();
            }
       // }
    }
}