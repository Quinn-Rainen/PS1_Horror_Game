using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    private AudioSource js_source;
    public GameObject blumonster;

    // Start is called before the first frame update
    void Start()
    {
        js_source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (blumonster.activeSelf && !js_source.isPlaying)
        {
            js_source.Play();
        }
    }
}
