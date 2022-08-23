using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kexuanduihua_jieshu : MonoBehaviour
{
    public GameObject duihua1f;
    public GameObject duihua2t;
    public GameObject duihua3f;
    public GameObject duihua4t;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            duihua1f.SetActive(false);
            duihua2t.SetActive(true);
            duihua3f.SetActive(false);
            duihua4t.SetActive(true);
            audio.Play();
        }
    }
}