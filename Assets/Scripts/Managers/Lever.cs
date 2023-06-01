using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool isActivated = false;
    public KeyCode interactKey = KeyCode.E;
    public Renderer leverRenderer;
    public Color activatedColor = Color.green;
    public Color deactivatedColor = Color.red;

    public event System.Action Interact;
    public float interactionRadius = 40f;
    public GameObject player;
    public Timer timer;

    private Color originalColor;

    private void Start()
    {

        originalColor = leverRenderer.material.color;
    }

    private void Update()
    {
        //taken from door script
        Vector3 distanceToObject = transform.position - player.transform.position; 
        distanceToObject.y = 0;
        if ((distanceToObject.magnitude <= interactionRadius) && Input.GetKeyDown(interactKey))
        {
            Activate();
        }
    }

    public void Activate()
    {
        if (!isActivated)
        {
            isActivated = true;
            leverRenderer.material.color = activatedColor;
            Interact?.Invoke(); // Raise the Interact event


            timer.StartTimer(this);
        }
    }

    public void ResetLever()
    {
        isActivated = false;
        leverRenderer.material.color = deactivatedColor; 
    }

}