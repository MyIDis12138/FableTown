using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duihuafushide : MonoBehaviour
{
    public GameObject player;
    public GameObject position;
    public GameObject duihua1;
    public GameObject duihua2;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<GameObject>();
        position = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            duihua1.SetActive(false);
            duihua2.SetActive(true);
            audio.Play();
            player.transform.position = position.transform.position;
            Debug.Log(player.transform.position);
        }
    }
}
