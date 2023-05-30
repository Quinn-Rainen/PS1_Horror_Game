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
    public Timer timer; // Reference to the Timer script

    private Color originalColor;

    private void Start()
    {
        // Store the original color of the lever renderer
        originalColor = leverRenderer.material.color;
    }

    private void Update()
    {
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
            leverRenderer.material.color = activatedColor; // Change the lever color to green
            Interact?.Invoke(); // Raise the Interact event


            timer.StartTimer(this);
        }
    }

    public void ResetLever()
    {
        isActivated = false;
        leverRenderer.material.color = deactivatedColor; // Reset the lever color to its deactivated color
    }

}