using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ESC : MonoBehaviour
{
    private void Start()
    {
        /*查找按钮组件并添加事件(点击事件)*/
    this.GetComponent<Button>().onClick.AddListener(OnClick);
    }
    // Start is called before the first frame update
    private void OnClick()
    {
    UnityEditor.EditorApplication.isPlaying = false;
    Application.Quit();
     }
}
