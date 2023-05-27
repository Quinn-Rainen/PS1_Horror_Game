using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetVolSliderPos : MonoBehaviour
{
    public Slider slide;
    void Start()
    {
        slide = GetComponent<Slider>();
        slide.value = PlayerPrefs.GetFloat("volume");
    }
}
