using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider控制2 : MonoBehaviour
{
    public AudioSource asound1;
    public AudioSource asound2;
    public Slider slider1;
    public Slider slider2;


    // Update is called once per frame
    public void Control_sound()
    {
        asound1.volume = slider1.value;
        asound2.volume = slider1.value;
        slider2.value = slider1.value;
    }
}
