using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Player's Current Facing")]
    public Facing facing;
    [Header("Object of type 'Animator'")]
    [SerializeField]
    private Animator anim;
    [Header("Object of type 'AudioSource'")]
    [SerializeField]
    private AudioSource audioSource;
    [Header("Object of type 'Player'")]
    [SerializeField]
    private Player player;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GetComponent<Player>();
        //To check if the player is touching the ground at regular intervals
        InvokeRepeating("CheckGround", 0.5f, 0.2f);
    }

    //Handles Player facing for instantiating projectiles
    public enum Facing
    {
        Up, Down, Left, Right
    };

    // Update is called once per frame
    void Update()
    {
        /* This is the cleanest way I've found to do it so far (not too clean, I know). 
        The reason I have them branched out is because I have to bow to the syntax of Unity's
        Input system. It was the only way I could find to get two controllers working and the
        reason there was originally two player scripts*/ 
        if (CompareTag("Player1"))
        {
            if (!anim.GetBool("dead"))
            {
                if (Input.GetAxis("Horizontal") >= 0.05f)
                {
                    MoveRight();
                }
                if (Input.GetAxis("Horizontal") <= -0.05f)
                {
                    MoveLeft();
                }
                if (Input.GetAxis("Horizontal") == 0)
                {
                    anim.SetBool("walk", false);
                }
                if (Input.GetAxis("Vertical") >= 0.05f)
                {
                    LookUp();
                }
                if (Input.GetAxis("Vertical") <= -0.05f)
                {
                    LookDown();
                }

                if (Input.GetButtonDown("RangeAttack"))
                {
                    Shoot();
                }


                if (Input.GetButtonDown("Jump"))
                {
                    Jump();
                }

                if (Input.GetButtonDown("Taunt") && !anim.GetBool("walk") && !anim.GetBool("jump"))
                {
                    Taunt();
                }

                if (player.health <= 0)
                {
                    Death();
                }
            }
        } else if (CompareTag("Player2"))
        {
            if (!anim.GetBool("dead"))
            {
                if (Input.GetAxis("P2Horizontal") >= 0.05f)
                {
                    MoveRight();
                }
                if (Input.GetAxis("P2Horizontal") <= -0.05f)
                {
                    MoveLeft();
                }
                if (Input.GetAxis("P2Horizontal") == 0)
                {
                    anim.SetBool("walk", false);
                }
                if (Input.GetAxis("P2Vertical") >= 0.05f)
                {
                    LookUp();
                }
                if (Input.GetAxis("P2Vertical") <= -0.05f)
                {
                    LookDown();
                }

                if (Input.GetButtonDown("P2RangeAttack"))
                {
                    Shoot();
                }


                if (Input.GetButtonDown("P2Jump"))
                {
                    Jump();
                }

                if (Input.GetButtonDown("P2Taunt") && !anim.GetBool("walk") && !anim.GetBool("jump"))
                {
                    Taunt();
                }

                if (player.health <= 0)
                {
                    Death();
                }
            }
        }
    }

    void Taunt()
    {
        audioSource.clip = player.tauntSound;
        audioSource.pitch = Random.Range(0.75f, 1f);
        audioSource.Play();
        anim.SetTrigger("taunt");
    }

    void Death()
    {
        audioSource.clip = player.deathSound;
        audioSource.Play();
        anim.SetTrigger("fall");
        anim.SetBool("walk", false);
        anim.SetBool("jump", false);
        anim.SetBool("upIdle", false);
        anim.SetBool("downIdle", false);
        anim.SetBool("taunt", false);
        anim.SetBool("dead", true);
        player.Die();
    }

    void Jump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -0.5f), Vector2.down, 0.5f);
        if (hit.collider != null)
        {
            audioSource.clip = player.jumpSound;
            audioSource.pitch = Random.Range(0.5f, 1f);
            audioSource.Play();
            anim.SetBool("jump", true);
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * player.jumpHeight);
        }
    }

    void Shoot()
    {
        anim.SetTrigger("shoot");
        audioSource.clip = player.shootSound;
        audioSource.pitch = Random.Range(0.5f, 1f);
        audioSource.Play();
        switch (facing)
        {
            case (Facing.Right):
                Projectile projR = Instantiate(player.projectile, transform.position + new Vector3(0.5f, 0), Quaternion.identity);
                projR.GetComponent<Rigidbody2D>().AddForce(Vector2.right * player.projectileSpeed);
                break;
            case (Facing.Left):
                Projectile projL = Instantiate(player.projectile, transform.position + new Vector3(-0.5f, 0), Quaternion.identity);
                projL.GetComponent<Rigidbody2D>().AddForce(Vector2.left * player.projectileSpeed);
                break;
            case (Facing.Up):
                Projectile projUp = Instantiate(player.projectile, transform.position + Vector3.up, Quaternion.identity);
                projUp.GetComponent<Rigidbody2D>().AddForce(Vector2.up * player.projectileSpeed);
                break;
            case (Facing.Down):
                Projectile projDown = Instantiate(player.projectile, transform.position + Vector3.down, Quaternion.identity);
                projDown.GetComponent<Rigidbody2D>().AddForce(Vector2.down * player.projectileSpeed);
                break;
        }
    }

    void MoveRight()
    {
        anim.SetBool("upIdle", false);
        anim.SetBool("downIdle", false);
        gameObject.GetComponent<SpriteRenderer>().flipX = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0), Vector2.right, 0.05f);
        if (hit.collider == null)
        {
            anim.SetBool("walk", true);
            transform.position += Vector3.right * player.moveSpeed * Time.deltaTime;
        }
        facing = Facing.Right;
    }

    void MoveLeft()
    {
        anim.SetBool("upIdle", false);
        anim.SetBool("downIdle", false);
        this.GetComponent<SpriteRenderer>().flipX = true;
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-0.5f, 0), Vector2.left, 0.05f);
        if (hit.collider == null)
        {
            anim.SetBool("walk", true);
            transform.position += Vector3.left * player.moveSpeed * Time.deltaTime;
            Debug.Log("clear");
        }
        facing = Facing.Left;
    }

    void LookUp()
    {
        anim.SetBool("upIdle", true);
        anim.SetBool("downIdle", false);
        anim.SetBool("walk", false);
        facing = Facing.Up;
    }

    void LookDown()
    {
        anim.SetBool("downIdle", true);
        anim.SetBool("upIdle", false);
        anim.SetBool("walk", false);
        facing = Facing.Down;
    }

    void CheckGround()
    {
        RaycastHit2D checkGround = Physics2D.Raycast(transform.position + new Vector3(0, -0.5f), Vector2.down, 0.5f);
        if (checkGround.collider != null)
        {
            anim.SetBool("jump", false);
        }
    }
}

