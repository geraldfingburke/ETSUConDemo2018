using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/**
 * <summary>
 * Game Manager is for keeping track of game state, lives, score, and ending a match.
 * When player reaches 3, the match is over and it will play a win screen, then go to main menu
 * ~Allen Oliver
 * </summary>
 */
public enum GameState
{
    WIN,
    LOSE,
    DRAW,
    
}

public class GameStateManager : MonoBehaviour {
    [Header("Player Health")]
    public int player1Health;
    public int player2Health;
    [Header("Player Scores")]
    public int player1Score;
    public int player2Score;
    [Header("Score Needed to Win Match")]
    public int maxScoreNeeded;
    [Header("Current State the game is in.")]
    public GameState state;

    /**
     * <summary>
     * Keeps Game Manager alive between scenes
     * ~Allen Oliver
     * </summary>
     */

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); 
    }

    void Start () {
		
	}
	

	void Update () {
		
	}

    public void KillPlayer(GameObject player)
    {
                
    }
    
    public void CheckForMatchOver()
    {
        if(player1Score >= maxScoreNeeded || player2Score >= maxScoreNeeded)
        {
            if(player1Score > player2Score)
            {
                //playerOneWins
            }
            else if(player2Score > player1Score)
            {
                //playerTwoWins
            }
            else
            {
                CreateNextLevel();
            }
        }
    }

    public void CreateNextLevel()
    {
        //will inherit and implement the random generator and create a new level
    }
        

}
