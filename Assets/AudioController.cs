using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public GameObject bgm;

	void Awake ()
    {
        if (!FindObjectOfType<BGM>())
        {
            Instantiate(bgm);
        }
    }
}
