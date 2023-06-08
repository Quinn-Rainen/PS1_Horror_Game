using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playDelayed : MonoBehaviour
{
    AudioSource l3_start_source;
    private bool has_played = false;

    // Start is called before the first frame update
    void Start()
    {
        l3_start_source = GetComponent<AudioSource>();
        l3_start_source.PlayDelayed(2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isPaused)
        {
            l3_start_source.Stop();
        }
        else
        {
            if (! l3_start_source.isPlaying && ! has_played)
            {
                l3_start_source.Play();
            }
            else{
                has_played = true;
            }
        }
    }
}
