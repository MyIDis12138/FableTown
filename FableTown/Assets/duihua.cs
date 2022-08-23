using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duihua : MonoBehaviour
{
    public GameObject duihua1;
    public GameObject duihua2;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        //duihua1 = GetComponent<GameObject>();
        //duihua2 = GetComponent<GameObject>();
        //audio = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            duihua1.SetActive(false);
            duihua2.SetActive(true);
            audio.Play();

        }
    }
}
