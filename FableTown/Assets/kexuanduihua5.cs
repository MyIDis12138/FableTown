using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kexuanduihua5 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject kexuanduihua1;
    public GameObject kexuanduihua2;
    public GameObject kexuanduihua3;
    public GameObject kexuanduihua4;
    public GameObject duihua5f;
    public GameObject duihua6f;
    public GameObject renwut;
    public GameObject renwuf;
    public AudioSource audio;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            duihua6f.SetActive(false);
            renwuf.SetActive(false);
            renwut.SetActive(true);
            audio.Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            duihua5f.SetActive(false);
            kexuanduihua1.SetActive(true);
            audio.Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            duihua5f.SetActive(false);
            kexuanduihua2.SetActive(true);
            audio.Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            duihua5f.SetActive(false);
            kexuanduihua3.SetActive(true);
            audio.Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            duihua5f.SetActive(false);
            kexuanduihua4.SetActive(true);
            audio.Play();
        }
    }
}

