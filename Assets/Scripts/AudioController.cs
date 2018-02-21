using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public GameObject bgm;
    public GameObject gsm;

	void Awake ()
    {
        if (!FindObjectOfType<BGM>())
        {
            Instantiate(bgm);
        }
        if (!FindObjectOfType<GameStateManager>())
        {
            Instantiate(gsm);
        }
    }
}
