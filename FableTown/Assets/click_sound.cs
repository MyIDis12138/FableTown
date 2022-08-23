using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class click_sound : MonoBehaviour
{
	public GameObject sound;
	public void OnMouseUp()
	{
		sound.SetActive(true);
	}
}
