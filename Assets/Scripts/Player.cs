using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public enum Facing
{
    Up, Down, Left, Right
};

public class Player : MonoBehaviour
{
    [Header("Object of type 'Animator'")]
    [SerializeField]
    private Animator anim;
    [Header("Player Health")]
    public float health;
    [Header("How Fast Player Can Move")]
    public float moveSpeed;
    [Header("How high player can jump")]
    public float jumpHeight;
    [Header("Object of type 'Projectile'")]
    public Projectile projectile;
    [Header("How fast The projectile can move")]
    public float projectileSpeed;
    [Header("Object of type 'GameStateManager'")]
    [SerializeField]
    private GameStateManager gameStateManager;
    [Header("Object of type 'AudioSource'")]
    public AudioSource audioSource;
    [Header("Clip for Shooting Sound Effect")]
    public AudioClip shootSound;
    [Header("Clip for Jumping Sound Effect")]
    public AudioClip jumpSound;
    [Header("Clip for Taunting Sound Effect")]
    public AudioClip tauntSound;
    [Header("Clip for Death Sound Effect")]
    public AudioClip deathSound;
    //TODO port this and associated functionality to Game State Manager
    [Header("UI Text for Player's current health")]
    public Text healthText; 

    void Start()
    {
        gameStateManager = FindObjectOfType<GameStateManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = (health * 10).ToString();
    }

    public void Die()
    {
        if (CompareTag("Player1"))
        {
            gameStateManager.player1Score++;
        } else if (CompareTag("Player2"))
        {
            gameStateManager.player2Score++;
        }

        gameStateManager.CheckForMatchOver();
    }

    /*This is only for TNT Explosions, however, if we were to add colliders to
     any other particles, this would become a problem*/
    void OnParticleCollision (GameObject other)
    {
        health = 0;
    }
}
    

