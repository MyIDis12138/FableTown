using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWep : MonoBehaviour
{
    public AudioSource HitAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void OnCollisionEnter(Collision other)
    {
        HitAudio.Play();
        other.rigidbody.AddForce(Vector3.forward*10f,ForceMode.Impulse);

        //Debug.Log("Hit");
    }


    

    // Update is called once per frame
    void Update()
    {

    }
}
