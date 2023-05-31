using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UserOptions : MonoBehaviour
{
    public float sensitivityPref;
    public float volumePref;
    public AudioMixer audioMixer;

    private void Start()
    {
        volumePref = PlayerPrefs.GetFloat("volume");
        sensitivityPref = PlayerPrefs.GetFloat("sensitivity");
        if (sensitivityPref == 0)
        {
            sensitivityPref = 20;
        }
    }

    private void Update()
    {
        PlayerPrefs.SetFloat("volume",volumePref);
        PlayerPrefs.SetFloat("sensitivity",sensitivityPref);
    }

    public void SensitivityUpdater(float sensitivity)
    {
        sensitivityPref = sensitivity;
    }

    public void VolumeUpdater(float volume)
    {
        volumePref = volume;
        audioMixer.SetFloat("volume", volume);
    }
}
