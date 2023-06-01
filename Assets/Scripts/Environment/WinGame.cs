using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    private AudioSource scienVoice;

 

    void Start()
    {
        scienVoice = GetComponent<AudioSource>();
        scienVoice.Stop();


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scienVoice.Play();

        }
    }

}