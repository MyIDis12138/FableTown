using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timecon : MonoBehaviour
{
    // Start is called before the first frame update
    void update()
    {
        if(Input.GetMouseButton(0)){
            Time.timeScale = 1;
        }
    }


}
