using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen2 : MonoBehaviour
{
	public GameObject Door1;
	public GameObject Door2;

	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Player")
		{
			Animator Anima1 = Door1.GetComponent<Animator>();
			Debug.Log("Open Called");
			Anima1.SetTrigger("Open");
			Animator Anima2 = Door2.GetComponent<Animator>();
			//Debug.Log("Open Called");
			Anima2.SetTrigger("Open");
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			Animator Anima1 = Door1.GetComponent<Animator>();
			Debug.Log("Close Called");
			Anima1.SetTrigger("Close");
			Animator Anima2 = Door2.GetComponent<Animator>();
			//Debug.Log("Open Called");
			Anima2.SetTrigger("Close");
		}
	}
}
