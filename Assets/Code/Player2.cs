using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {

    #region Public Variables
    [Header("Where is the player facing?")]
    private int facing;
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
    [Header("When true, player will have 'Rapid Fire'")]
    public bool rapidFireActive;

    #endregion

    #region Private Variables
    [Header("Holds float of last bullet shot")]
    private float lastFire = 0f;
    [Header("Fire rate for rapic fire. (How fast shoot)")]
    private float fireRate = .5f;
    #endregion

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("P2Horizontal") >= 0.05f)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            Debug.DrawRay(transform.position, Vector3.right, Color.red, 10f);
            this.GetComponent<SpriteRenderer>().flipX = false;
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0), Vector2.right, 0.05f);
            if (hit.collider == null)
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                Debug.Log("clear");
            }
            else
                Debug.Log("blocked");
            
            facing = 0;
        }
        if (Input.GetAxis("P2Horizontal") <= -0.05f)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-0.5f, 0), Vector2.left, 0.05f);
            if (hit.collider == null)
            {
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                Debug.Log("clear");
            }
            else
            {
                Debug.Log("blocked");
            }
            facing = 1;
        }
        if (Input.GetAxis("P2Vertical") >= 0.05f)
        {
            facing = 2;
        }
        if (Input.GetAxis("P2Vertical") <= -0.05f)
        {
            facing = 3;
        }
        if(!rapidFireActive)
        {
            if (Input.GetButtonDown("P2RangeAttack"))
            {
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
        }
        else
        {
            if (Input.GetButton("P2RangeAttack") && Time.time > lastFire)
            {
                switch (facing)
                {
                    case (0):
                        lastFire = Time.time + fireRate;
                        Projectile projR = Instantiate(projectile, transform.position + Vector3.right, Quaternion.identity);
                        projR.gameObject.tag = "ProjectilePlayer2";
                        projR.GetComponent<Rigidbody2D>().AddForce(Vector2.right * projectileSpeed);
                        break;
                    case (1):
                        lastFire = Time.time + fireRate;
                        Projectile projL = Instantiate(projectile, transform.position + Vector3.left, Quaternion.identity);
                        projL.gameObject.tag = "ProjectilePlayer2";
                        projL.GetComponent<Rigidbody2D>().AddForce(Vector2.left * projectileSpeed);
                        break;
                    case (2):
                        lastFire = Time.time + fireRate;
                        Projectile projUp = Instantiate(projectile, transform.position + Vector3.up, Quaternion.identity);
                        projUp.gameObject.tag = "ProjectilePlayer2";
                        projUp.GetComponent<Rigidbody2D>().AddForce(Vector2.up * projectileSpeed);
                        break;
                    case (3):
                        lastFire = Time.time + fireRate;
                        Projectile projDown = Instantiate(projectile, transform.position + Vector3.down, Quaternion.identity);
                        projDown.gameObject.tag = "ProjectilePlayer2";
                        projDown.GetComponent<Rigidbody2D>().AddForce(Vector2.down * projectileSpeed);
                        break;
                }

            }
        }

        if (Input.GetButtonDown("P2Jump"))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -0.5f), Vector2.down, 0.5f);
            if (hit.collider != null)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
            }
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case ("SpeedPowerUp"):
                var speedUp = new SpeedPowerUp();
                Destroy(col, .3f);
                StartCoroutine(speedUp.SpeedUpPlayerTwo(gameObject));
                break;
            case ("RapidFire"):
                var rapidFire = new RapidFire();
                StartCoroutine(rapidFire.RapidFirePlayerOne(gameObject));
                Destroy(col.gameObject, .3f);
                break;
        }
    }

}
