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

    #region Variables
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
    [Header("List of Level Names/n Make sure they match the names in the build settings!!")]
    public string[] levels;
    [Header("Player One gameObject")]
    public Player playerOne;
    [Header("Player Two gameObject")]
    public Player2 playerTwo;
    #endregion

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
	

	void Update ()
    {
        CheckForMatchOver();	
	}
    /// <summary>
    /// For Handling player one deaths
    /// Adds score, then checks for match over
    /// if mach over, sends to win screen, else creates next level
    /// </summary>
    public void KillPlayerOne()
    {
        player2Score++;
        if (CheckForMatchOver())
        { } // go to win screen
        else
        { CreateNextLevel(); }
    }

    /// <summary>
    /// For Handling player two deaths
    /// Adds score, then checks for match over
    /// if mach over, sends to win screen, else creates next level
    /// </summary>
    public void KillPlayerTwo()
    {
        player1Score++;
        if (CheckForMatchOver())
        { } // go to win screen
        else
        { CreateNextLevel(); }
    }
    
    /// <summary>
    /// checks for match over and returns a true or false
    /// </summary>
    /// <returns> True or false for match over </returns>
    public bool CheckForMatchOver()
    {
        if(player1Score >= maxScoreNeeded || player2Score >= maxScoreNeeded)
        {
            if(player1Score > player2Score)
            {
                //playerOneWins
                return true;

            }
            else if(player2Score > player1Score)
            {
                //playerTwoWins
                return true;
            }
            else
            {
                return false;
            }
            
        }
        return false;
    }

    /// <summary>
    /// Moves to a random scene in the build index (Of battle stages)
    /// </summary>
    public void CreateNextLevel()
    {
        var level =  Random.Range(1, levels.Length);
        var levelName = levels[level].ToString();
        SceneManager.LoadSceneAsync(levelName);
    }
        

}
