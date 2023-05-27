using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodGraveMindAudio : MonoBehaviour
{
    private AudioSource gravemindVoice;
   // private bool hasPlayed;

    void Start()
    {
        gravemindVoice = GetComponent<AudioSource>();
        gravemindVoice.Stop();
        //hasPlayed = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )//&& !hasPlayed)
        {
            gravemindVoice.Play();
            // hasPlayed = true;
        }
    }
}
