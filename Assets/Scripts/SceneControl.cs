using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown || Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") < 0 || Input.GetAxis("Vertical") > 0
            || Input.GetAxis("P2Horizontal") > 0 || Input.GetAxis("P2Horizontal") < 0 || Input.GetAxis("P2Vertical") < 0 || Input.GetAxis("P2Vertical") > 0)
        {
            Time.timeScale = 1;
            Destroy(gameObject);
        }
	}
}
