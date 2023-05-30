using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAbientSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] randClips;
    private int clip_ind;
    private AudioSource rc_AudioSource;
    // private bool if_playing = false;

    // Start is called before the first frame update
    void Start()
    {
        rc_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isPaused) {
            rc_AudioSource.Stop();
        }
        else 
        {
            if (! rc_AudioSource.isPlaying)
            {
                clip_ind = Random.Range(0, randClips.Length-1);
                rc_AudioSource.clip = randClips[clip_ind];
                
                // play a random sound every 30 to 60 seconds
                rc_AudioSource.PlayDelayed(Random.Range(30.0f, 60.0f));
            }
        }
    }
}
