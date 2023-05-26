using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private string keypadTag = "Keypad";
    [SerializeField] private Material highlightMaterial;
    //[SerializeField] private Material defaultMaterial;
    public GameObject player;
    public float interactionRadius = 50f;

    private Transform _selection;
    [SerializeField] private Camera cam;
    // Update is called once per frame
    void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.materials[0].DisableKeyword ("_EMISSION");
            selectionRenderer.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
            _selection = null;
        }
        if (cam != null) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                
                Vector3 distanceToObject = selection.position - player.transform.position; 
                distanceToObject.y = 0;
                if (selection.CompareTag(selectableTag) || selection.CompareTag(keypadTag))
                {
                    var selectionRenderer = selection.GetComponent<Renderer>();
                    if ((selection != null) && (distanceToObject.magnitude <= interactionRadius))
                    {
                        //selectionRenderer.material = highlightMaterial;
                        selectionRenderer.materials[0].EnableKeyword ("_EMISSION");
                        selectionRenderer.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.None;
                    }

                    _selection = selection;
                }
            }
        }
    }
}
