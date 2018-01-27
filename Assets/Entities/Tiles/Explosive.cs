using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Explode", Random.Range(10, 20));
	}
	
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Projectile"))
        {
            Explode();
        }
    }

    void Explode ()
    {
        
    }
}
