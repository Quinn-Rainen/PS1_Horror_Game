using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistVoice : MonoBehaviour
{
    private AudioSource scienVoice;
   // private bool hasPlayed;

    void Start()
    {
        scienVoice = GetComponent<AudioSource>();
        scienVoice.Stop();
        //hasPlayed = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )//&& !hasPlayed)
        {
            scienVoice.Play();
            // hasPlayed = true;
        }
    }
}