using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keduihua8 : MonoBehaviour
{
    public GameObject kexuanduihua1;
    public GameObject duihua5f;
    public AudioSource audio;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            duihua5f.SetActive(false);
            kexuanduihua1.SetActive(true);
            audio.Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            duihua5f.SetActive(false);
            kexuanduihua1.SetActive(true);
            audio.Play();
        }
    }
}
