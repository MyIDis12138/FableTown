using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sixiangjieshu : MonoBehaviour
{
    public GameObject duihua1f;
    public GameObject duihua2f;
    public GameObject duihua4t;
    public AudioSource audio;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            duihua1f.SetActive(false);
            duihua2f.SetActive(false);
            duihua4t.SetActive(true);
            audio.Play();
        }
    }
}