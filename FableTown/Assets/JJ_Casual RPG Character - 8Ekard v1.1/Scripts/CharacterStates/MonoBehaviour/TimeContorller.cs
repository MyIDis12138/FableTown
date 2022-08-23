using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeContorller : MonoBehaviour
{
    private void FixedUpdate()
    {
        //Debug.Log(Time.timeScale);
    }
    public void StopTime()
    {
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }
}
