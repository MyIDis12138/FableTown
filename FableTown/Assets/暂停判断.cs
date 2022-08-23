using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 暂停判断 : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;
   

    // Update is called once per frame
    void Update()
    {
        if (gameObject1.activeSelf)
        {
            gameObject2.SetActive(true);
            gameObject3.SetActive(true);
        }
    }
}
