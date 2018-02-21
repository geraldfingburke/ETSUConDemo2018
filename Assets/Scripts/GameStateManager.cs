using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/**
 * <summary>
 * Game Manager is for keeping track of game state, lives, score, and ending a match.
 * When player reaches 3, the match is over and it will play a win screen, then go to main menu
 * ~Allen Oliver
 * </summary>
 */

public class GameStateManager : MonoBehaviour {
    [Header("Player Scores")]
    public int player1Score;
    public int player2Score;
    [Header("Score Needed to Win Match")]
    public int maxScoreNeeded;
    public GameObject checkovWins;
    public GameObject aliceWins;
    public GameObject tie;

    private Canvas canvas;
    private bool paused;
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

    void OnSceneLoaded ()
    {
        
    }

    void Start () {
        
    }
	

	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            CreateNextLevel();
        }
    }

    public void KillPlayer(GameObject player)
    {
                
    }
    
    public void CheckForMatchOver()
    {
        canvas = FindObjectOfType<Canvas>();
        if(player1Score >= maxScoreNeeded || player2Score >= maxScoreNeeded)
        {
            if(player1Score > player2Score)
            {
                player1Score = 0;
                player2Score = 0;
                Instantiate(aliceWins, canvas.transform);
                Invoke("CreateNextLevel", 3f);
            }
            else if(player2Score > player1Score)
            {
                player1Score = 0;
                player2Score = 0;
                Instantiate(checkovWins, canvas.transform);
                Invoke("CreateNextLevel", 3f);
            }
            else
            {
                player1Score = 0;
                player2Score = 0;
                Instantiate(tie, canvas.transform);
                Invoke("CreateNextLevel", 3f);
            }
        } else
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }

    public void CreateNextLevel()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        if (scene < 2)
        {
            SceneManager.LoadScene((scene += 1), LoadSceneMode.Single);
        } else if (scene == 2)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        } 
    }
        

}
