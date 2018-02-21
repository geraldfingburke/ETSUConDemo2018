using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    private GameStateManager gsm;
    private Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        gsm = FindObjectOfType<GameStateManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (CompareTag("AliceScore"))
        {
            text.text = gsm.player1Score.ToString();
        } else if (CompareTag("CheckovScore"))
        {
            text.text = gsm.player2Score.ToString();
        }
	}
}
