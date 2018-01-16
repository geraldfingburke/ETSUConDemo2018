using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [Header("Game Manager Instance")]
    public GameStateManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameStateManager>();
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case ("Breakable"):
                Destroy(gameObject);
                break;
            case ("Player1"):

                Debug.Log("Should have died" + gameObject.name);
                gm.player2Score++;
                Destroy(gameObject);
                Destroy(col.gameObject);
                break;
            case ("Player2"):
                Debug.Log("Should have died" + gameObject.name);
                gm.player1Score++;
                Destroy(gameObject);
                Destroy(col.gameObject);
                break;
            default:
                Destroy(gameObject);
                break;
        }


    }
}
