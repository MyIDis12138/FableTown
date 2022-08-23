using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duihua3 : MonoBehaviour
{
    public GameObject duihua1f;
    public GameObject duihua2f;
    public GameObject duihua3t;
    public GameObject duihua4t;
    public GameObject qiao;
    public GameObject fushide;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Function Called");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            duihua1f.SetActive(false);
            duihua2f.SetActive(false);
            duihua3t.SetActive(true);
            duihua4t.SetActive(true);
            fushide.SetActive(false);
            qiao.SetActive(true);
            audio.Play();
        }
    }
}