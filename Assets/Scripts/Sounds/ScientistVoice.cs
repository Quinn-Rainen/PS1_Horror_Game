using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistVoice : MonoBehaviour
{
    private AudioSource scienVoice;
    private AudioSource scienVoice2;

    private bool hasPlayed;

    void Start()
    {
        scienVoice = GetComponent<AudioSource>();
        // scienVoice.Stop();

        scienVoice2 = GetComponent<AudioSource>();
        // scienVoice2.Stop();
        hasPlayed = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            scienVoice.Play();
            hasPlayed = true;
        }
    }

    void OnTriggerExit(Collider other){
        if (other.CompareTag("Player") && !hasPlayed)
        {
            scienVoice2.Play();
            hasPlayed = true;
        }      
    }
}