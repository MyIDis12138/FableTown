using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kexuanduihua5jieshu : MonoBehaviour
{
    public GameObject duihua1f;
    public GameObject duihua2f;
    public GameObject duihua4t;
    public GameObject duihua5t;
    public AudioSource audio;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            duihua1f.SetActive(false);
            duihua2f.SetActive(false);
            duihua4t.SetActive(true);
            duihua5t.SetActive(true);
            audio.Play();
        }
    }
}

