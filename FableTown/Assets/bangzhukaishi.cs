using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bangzhukaishi : MonoBehaviour
{
    public GameObject Object1f;
    public GameObject Object2f;
    public GameObject Object3t;
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
            Object1f.SetActive(false);
            Object2f.SetActive(false);
            Object3t.SetActive(true);
            audio.Play();
        }
    }
}
