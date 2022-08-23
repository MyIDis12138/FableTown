using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duihuajieshu_zhixian : MonoBehaviour
{
    public GameObject duihua1f;
    public GameObject duihua2f;
    public GameObject duihua3t;
    public AudioSource audio;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            duihua1f.SetActive(false);
            duihua2f.SetActive(false);
            duihua3t.SetActive(true);
            audio.Play();
        }
    }
}