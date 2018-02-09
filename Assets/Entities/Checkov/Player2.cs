using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour {

    [Header("Where is the player facing?")]
    private int facing;
    [Header("Object of type 'Animator'")]
    private Animator anim;
    [Header("Player Health")]
    public float health;
    [Header("How Fast Player Can Move")]
    public float moveSpeed;
    [Header("how high player can jump")]
    public float jumpHeight;
    [Header("How fast The projectile can move")]
    public float projectileSpeed;
    [Header("Object of type 'Projectile'")]
    public Projectile projectile;
    private int deathCount;
    public AudioSource audioSource;
    public AudioClip shootSound;
    public AudioClip jumpSound;
    public AudioClip tauntSound;
    public AudioClip deathSound;

    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("CheckGround", 0.5f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.GetBool("dead"))
        {
            if (Input.GetAxis("P2Horizontal") >= 0.05f)
            {
                anim.SetBool("upIdle", false);
                anim.SetBool("downIdle", false);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0), Vector2.right, 0.05f);
                if (hit.collider == null)
                {
                    anim.SetBool("walk", true);
                    transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                }
                else
                {
                    Debug.Log("blocked");
                }
                facing = 0;
            }
            if (Input.GetAxis("P2Horizontal") <= -0.05f)
            {
                anim.SetBool("upIdle", false);
                anim.SetBool("downIdle", false);
                this.GetComponent<SpriteRenderer>().flipX = true;
                RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-0.5f, 0), Vector2.left, 0.05f);
                if (hit.collider == null)
                {
                    anim.SetBool("walk", true);
                    transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                    Debug.Log("clear");
                }
                else
                {
                    Debug.Log("blocked");
                }
                facing = 1;
            }
            if (Input.GetAxis("P2Horizontal") == 0)
            {
                anim.SetBool("walk", false);
            }
            if (Input.GetAxis("P2Vertical") >= 0.05f)
            {
                anim.SetBool("upIdle", true);
                anim.SetBool("downIdle", false);
                anim.SetBool("walk", false);
                facing = 2;
            }
            if (Input.GetAxis("P2Vertical") <= -0.05f)
            {
                anim.SetBool("downIdle", true);
                anim.SetBool("upIdle", false);
                anim.SetBool("walk", false);
                facing = 3;
            }

            if (Input.GetButtonDown("P2RangeAttack"))
            {
                anim.SetTrigger("shoot");
                audioSource.clip = shootSound;
                audioSource.pitch = Random.Range(0.5f, 1f);
                audioSource.Play();
                switch (facing)
                {
                    case (0):
                        Projectile projR = Instantiate(projectile, transform.position + Vector3.right, Quaternion.identity);
                        projR.GetComponent<Rigidbody2D>().AddForce(Vector2.right * projectileSpeed);
                        break;
                    case (1):
                        Projectile projL = Instantiate(projectile, transform.position + Vector3.left, Quaternion.identity);
                        projL.GetComponent<Rigidbody2D>().AddForce(Vector2.left * projectileSpeed);
                        break;
                    case (2):
                        Projectile projUp = Instantiate(projectile, transform.position + Vector3.up, Quaternion.identity);
                        projUp.GetComponent<Rigidbody2D>().AddForce(Vector2.up * projectileSpeed);
                        break;
                    case (3):
                        Projectile projDown = Instantiate(projectile, transform.position + Vector3.down, Quaternion.identity);
                        projDown.GetComponent<Rigidbody2D>().AddForce(Vector2.down * projectileSpeed);
                        break;
                }
            }


            if (Input.GetButtonDown("P2Jump"))
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -0.5f), Vector2.down, 0.5f);
                if (hit.collider != null)
                {
                    audioSource.clip = jumpSound;
                    audioSource.pitch = Random.Range(0.5f, 1f);
                    audioSource.Play();
                    anim.SetBool("jump", true);
                    GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
                }
            }

            if (Input.GetButtonDown("P2Taunt") && !anim.GetBool("walk") && !anim.GetBool("jump"))
            {
                audioSource.clip = tauntSound;
                audioSource.pitch = Random.Range(0.75f, 1f);
                audioSource.Play();
                anim.SetTrigger("taunt");
            }

            if (health <= 0)
            {
                audioSource.clip = deathSound;
                audioSource.Play();
                anim.SetTrigger("fall");
                anim.SetBool("dead", true);
                Invoke("Death", 100f * Time.deltaTime);
            }
        }
    }

    void Death()
    {
        deathCount++;
        SceneManager.LoadScene("Main");
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
