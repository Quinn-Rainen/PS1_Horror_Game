using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchPromptTrigger : MonoBehaviour
{
    public GameObject CrouchPrompt;

    void Start()
    {
        CrouchPrompt.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            //_switchBehavior.DoorLockedStatus();
            CrouchPrompt.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            //_switchBehavior.DoorLockedStatus();
            CrouchPrompt.SetActive(false);
        }
    }
}
