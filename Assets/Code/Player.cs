using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
    [Header("Game Manager Instance")]
    public GameStateManager gm;
    #endregion

    #region Private Variables
    [Header("Holds float of last bullet shot")]
    private float lastFire = 0f;
    private float fireRate = .1f;
    #endregion


    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") >= 0.05f)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0), Vector2.right, 0.05f);
            if (hit.collider == null)
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
            else
            {
                Debug.Log("blocked");
            }
            facing = 0;
        }
        if (Input.GetAxis("Horizontal") <= -0.05f)
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
        if (Input.GetAxis("Vertical") >= 0.05f)
        {
            facing = 2;
        }
        if (Input.GetAxis("Vertical") <= -0.05f)
        {
            facing = 3;
        }
        if(!rapidFireActive)
        {
            if (Input.GetButtonDown("RangeAttack"))
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
            if (Input.GetButton("RangeAttack") && Time.time > lastFire)
            {
                switch (facing)
                {
                    case (0):
                        lastFire = Time.time + fireRate;
                        Projectile projR = Instantiate(projectile, transform.position + Vector3.right, Quaternion.identity);
                        projR.gameObject.tag = "ProjectilePlayer1";
                        projR.GetComponent<Rigidbody2D>().AddForce(Vector2.right * projectileSpeed);
                        break;
                    case (1):
                        lastFire = Time.time + fireRate;
                        Projectile projL = Instantiate(projectile, transform.position + Vector3.left, Quaternion.identity);
                        projL.gameObject.tag = "ProjectilePlayer1";
                        projL.GetComponent<Rigidbody2D>().AddForce(Vector2.left * projectileSpeed);
                        break;
                    case (2):
                        lastFire = Time.time + fireRate;
                        Projectile projUp = Instantiate(projectile, transform.position + Vector3.up, Quaternion.identity);
                        projUp.gameObject.tag = "ProjectilePlayer1";
                        projUp.GetComponent<Rigidbody2D>().AddForce(Vector2.up * projectileSpeed);
                        break;
                    case (3):
                        lastFire = Time.time + fireRate;
                        Projectile projDown = Instantiate(projectile, transform.position + Vector3.down, Quaternion.identity);
                        projDown.gameObject.tag = "ProjectilePlayer1";
                        projDown.GetComponent<Rigidbody2D>().AddForce(Vector2.down * projectileSpeed);
                        break;
                }
            }
        }


            if (Input.GetButtonDown("Jump"))
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -0.5f), Vector2.down, 0.5f);
                if (hit.collider != null)
                {
                    this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
                }
            }
            if (health <= 0)
            {
                Destroy(gameObject); //".this" is not required  in unity. gameObject or lowercase transform refers to attached parent object  
            }
        }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="col"></param>
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.gameObject.tag)
        {
            case ("SpeedPowerUp"):
                var speedUp = new SpeedPowerUp();
                StartCoroutine(speedUp.SpeedUpPlayerOne(gameObject));
                Destroy(col.gameObject);
                break;
            case ("RapidFire"):
                var rapidFire = new RapidFire();
                StartCoroutine(rapidFire.RapidFirePlayerOne(gameObject));
                Destroy(col.gameObject, .3f);
                break;
        }
    }

    private IEnumerator waitForShortTime()
    {
        yield return new WaitForSeconds(1f);
    }
}

