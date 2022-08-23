using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kexuanduihua : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject kexuanduihua1;
    public GameObject kexuanduihua2;
    public GameObject duihua3f;
    public GameObject duihua4t;
    public GameObject duihua5f;
    public AudioSource audio;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            duihua3f.SetActive(false);
            duihua4t.SetActive(true);
            duihua5f.SetActive(false);
            audio.Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            duihua3f.SetActive(false);
            kexuanduihua1.SetActive(true);
            audio.Play();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            duihua3f.SetActive(false);
            kexuanduihua2.SetActive(true);
            audio.Play();
        }
    }
}


