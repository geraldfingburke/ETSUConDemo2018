using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour {

    private int facing;
    private Animator anim;

    public float health;
    public float moveSpeed;
    public float jumpHeight;
    public float projectileSpeed;
    public Projectile projectile;

    void Start ()
    {
        anim = this.GetComponent<Animator>();
    }

	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Horizontal") >= 0.05f)
        {
            anim.SetBool("UpIdle", false);
            this.GetComponent<SpriteRenderer>().flipX = false;
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0), Vector2.right, 0.05f);
            if (hit.collider == null)
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                anim.SetBool("Walking", true);
            }
            else
            {
                Debug.Log("blocked");
            }
            facing = 0;
        }
        if (Input.GetAxis("Horizontal") <= -0.05f)
        {
            anim.SetBool("UpIdle", false);
            this.GetComponent<SpriteRenderer>().flipX = true;
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-0.5f, 0), Vector2.left, 0.05f);
            if (hit.collider == null)
            {
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                anim.SetBool("Walking", true);
                Debug.Log("clear");
            }
            else
            {
                Debug.Log("blocked");
            }
            facing = 1;
        }
        if (Input.GetAxis("Horizontal") > -0.05f && Input.GetAxis("Horizontal") < 0.05f)
        {
            anim.SetBool("Walking", false);
        }
        if (Input.GetAxis("Vertical") >= 0.05f)
        {
            anim.SetBool("UpIdle", true);
            facing = 2;
        }
        if (Input.GetAxis("Vertical") <= -0.05f)
        {
            anim.SetBool("UpIdle", false);
            facing = 3;
        }
        if (Input.GetAxis("Vertical") > -0.05f && Input.GetAxis("Vertical") < 0.05f)
        {
            anim.SetBool("UpIdle", false);
        }
        if (Input.GetButtonDown("RangeAttack"))
        {
            anim.SetBool("Shooting", true);
            if (facing == 0)
            {
                Projectile proj = Instantiate(projectile, transform.position + Vector3.right, Quaternion.identity);
                proj.GetComponent<Rigidbody2D>().AddForce(Vector2.right * projectileSpeed);
            }
            else if (facing == 1)
            {
                Projectile proj = Instantiate(projectile, transform.position + Vector3.left, Quaternion.identity);
                proj.GetComponent<Rigidbody2D>().AddForce(Vector2.left * projectileSpeed);
            }
            else if (facing == 2)
            {
                Projectile proj = Instantiate(projectile, transform.position + Vector3.up, Quaternion.identity);
                proj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * projectileSpeed);
            }
            else if (facing == 3)
            {
                Projectile proj = Instantiate(projectile, transform.position + Vector3.down, Quaternion.identity);
                proj.GetComponent<Rigidbody2D>().AddForce(Vector2.down * projectileSpeed);
            }
        }
        if (Input.GetButtonUp("RangeAttack"))
        {
            anim.SetBool("Shooting", false);
            anim.SetBool("WalkShoot", false);
            anim.SetBool("UpShooting", false);
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
            SceneManager.LoadScene("Main");
            Destroy(this.gameObject);
        }
        if (Input.GetAxis("Vertical") >= 0.05f && Input.GetButtonDown("RangeAttack"))
        {
            anim.SetBool("UpShooting", true);
        }
        if ((Input.GetAxis("Horizontal") >= 0.05f || Input.GetAxis("Horizontal") <= -0.05f) && Input.GetButtonDown("RangeAttack"))
        {
            anim.SetBool("WalkShoot", true);
        }
        if (Input.GetButtonDown("Sprint"))
        {
            moveSpeed = moveSpeed * 1.25f;
        }
        if (Input.GetButtonUp("Sprint"))
        {
            moveSpeed = moveSpeed * 0.8f;
        }
	}
}
