using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehavior : MonoBehaviour
{
    [SerializeField] InventoryManager.AllItems _itemType;
    [SerializeField] SwitchBehavior _switchBehavior;
    
    public GameObject player;
    public float interactionRadius = 30f;

    public GameObject Canvas;
    public GameObject findTheKey;
    public GameObject findTheKeyS;


    void Update()
    {
        Vector3 distanceToObject = transform.position - player.transform.position; 
        distanceToObject.y = 0;
        if ((distanceToObject.magnitude <= interactionRadius) && Input.GetKeyDown(KeyCode.E))
        {
            InventoryManager.Instance.AddItem(_itemType);
                Destroy(gameObject);
                findTheKey.SetActive(false);
                findTheKeyS.SetActive(true);
                Canvas.GetComponent<ObjectiveUI>().openOverlay();
        }
    }
}
