using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public bool _isDoorOpen = false;
    Vector3 _doorClosedPos;
    Vector3 _doorOpenPos;
    float _doorSpeed = 10;

    AudioSource d_AudioSource;
    bool if_audio_played = false;

    void Start()
    {
        d_AudioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Awake()
    {
        _doorClosedPos = transform.position;
        _doorOpenPos = new Vector3(transform.position.x + 5f, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (_isDoorOpen)
        {
            OpenDoor();
        } else if (!_isDoorOpen)
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        if (transform.position != _doorOpenPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _doorOpenPos, _doorSpeed * Time.deltaTime);
        }

        // this is kind of a janky way of only playing the audio once
        // (just have a check to see if the audio has been played or
        // not), but Quinn and Zane couldn't come up with any better
        // ideas. 
        if (! if_audio_played)
        {
            d_AudioSource.Play();
            if_audio_played = true;
        }
    }

    void CloseDoor()
    {
        if (transform.position != _doorClosedPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _doorClosedPos, _doorSpeed * Time.deltaTime);
        }
    }
}
