using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//By: Triet Nguyen
public class AudioSetting : MonoBehaviour
{
    //set default value to 0.5
    public Slider audioSlider;
    public float defaultVolume = 0.5f;


    //Initialize current volume
    private float previousVolume;

    //Set audio slider to default value once game starts
    void Start()
    {
        //Set volume slider to default value at start
        audioSlider.value = defaultVolume;

        //Initialize mute toggle function and previousVolume at start
        previousVolume = defaultVolume;
    }

}
