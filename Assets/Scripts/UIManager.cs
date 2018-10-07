using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private GameStateManager gsm;
    [Header("UI Text Element for Player 1's Score")]
    public Text p1Score;
    [Header("UI Text Element for Player 2's Score")]
    public Text p2Score;
    [Header("UI Text Element for Player 1's Health")]
    public Text p1Health;
    [Header("UI Text Element for Player 2's Health")]
    public Text p2Health;

    public Player player1;
    public Player2 player2;
    
	// Use this for initialization
	void Start () {
        
        gsm = FindObjectOfType<GameStateManager>();
	}
	
	// Update is called once per frame
	void Update () {
        //Checks and updates player's health.
        //TODO figure out a good way to do this on value changed, maybe an event trigger on the parent object.
        p1Health.text = player1.health.ToString();
        p2Health.text = player2.health.ToString();
        //Checks and updates player's score
        //TODO I'd also like to do this one exclusively on value changed.
        p1Score.text = gsm.player1Score.ToString();
        p2Score.text = gsm.player2Score.ToString();
	}
}
