using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audio_victory : MonoBehaviour
{
    public GameObject button;
    public AudioSource audioSource;
   
    // Start is called before the first frame update
    void Start()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            button.SetActive(true);
        }
    }
}
