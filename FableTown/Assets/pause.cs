using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    // Start is called before the first frame update
    public void Timestop()
    {
        Time.timeScale = 0;
    }
    public void Timestart()
    {
        Time.timeScale = 1;
    }
}
