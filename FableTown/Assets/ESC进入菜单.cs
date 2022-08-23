using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ESC进入菜单 : MonoBehaviour
{
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;
    public GameObject DeathUI;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!gameObject3.activeInHierarchy&&!DeathUI.activeInHierarchy)
        {
            Time.timeScale = 0;
            gameObject1.SetActive(true);
            gameObject2.SetActive(true);
        } 
    }

}
