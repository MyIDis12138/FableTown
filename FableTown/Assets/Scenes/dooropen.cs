using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dooropen : MonoBehaviour
{

	public GameObject Door;


    void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Player")
		{
			Animator Anima = Door.GetComponent<Animator>();
			//Debug.Log("Open Called");
			Anima.SetTrigger("Open");
		}
	}
    private void OnTriggerExit(Collider other)
    {
		if (other.tag == "Player")
		{
			Animator Anima = Door.GetComponent<Animator>();
			Anima.SetTrigger("Close");
		}
	}
}