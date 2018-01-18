using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Explode", Random.Range(10, 20));
	}
	
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Projectile"))
        {
            Explode();
        }
    }

    void Explode ()
    {
        RaycastHit2D left = Physics2D.Raycast(transform.position, Vector2.left, Random.Range(1,3));
        RaycastHit2D right = Physics2D.Raycast(transform.position, Vector2.right, Random.Range(1, 3));
        RaycastHit2D up = Physics2D.Raycast(transform.position, Vector2.up, Random.Range(1, 3));
        RaycastHit2D down = Physics2D.Raycast(transform.position, Vector2.down, Random.Range(1, 3));
        RaycastHit2D upLeft = Physics2D.Raycast(transform.position, new Vector2(-1,1), Random.Range(1, 3));
        RaycastHit2D upRight = Physics2D.Raycast(transform.position, new Vector2(1,1), Random.Range(1, 3));
        RaycastHit2D downLeft = Physics2D.Raycast(transform.position, new Vector2(-1,-1), Random.Range(1, 3));
        RaycastHit2D downRight = Physics2D.Raycast(transform.position, new Vector2(-1,1), Random.Range(1, 3));

        if (left.collider.gameObject.CompareTag("Breakable"))
        {
            Destroy(left.collider.gameObject);
        } else if (left.collider.gameObject.CompareTag("Player1"))
        {
            FindObjectOfType<Player>().health = 0;
        } else if (left.collider.gameObject.CompareTag("Player2"))
        {
            FindObjectOfType<Player2>().health = 0;
        }
        if (right.collider.gameObject.CompareTag("Breakable"))
        {
            Destroy(right.collider.gameObject);
        }
        else if (right.collider.gameObject.CompareTag("Player1"))
        {
            FindObjectOfType<Player>().health = 0;
        }
        else if (right.collider.gameObject.CompareTag("Player2"))
        {
            FindObjectOfType<Player2>().health = 0;
        }
        if (up.collider.gameObject.CompareTag("Breakable"))
        {
            Destroy(up.collider.gameObject);
        }
        else if (up.collider.gameObject.CompareTag("Player1"))
        {
            FindObjectOfType<Player>().health = 0;
        }
        else if (up.collider.gameObject.CompareTag("Player2"))
        {
            FindObjectOfType<Player2>().health = 0;
        }
        if (down.collider.gameObject.CompareTag("Breakable"))
        {
            Destroy(down.collider.gameObject);
        }
        else if (down.collider.gameObject.CompareTag("Player1"))
        {
            FindObjectOfType<Player>().health = 0;
        }
        else if (down.collider.gameObject.CompareTag("Player2"))
        {
            FindObjectOfType<Player2>().health = 0;
        }
        if (upLeft.collider.gameObject.CompareTag("Breakable"))
        {
            Destroy(upLeft.collider.gameObject);
        }
        else if (upLeft.collider.gameObject.CompareTag("Player1"))
        {
            FindObjectOfType<Player>().health = 0;
        }
        else if (upLeft.collider.gameObject.CompareTag("Player2"))
        {
            FindObjectOfType<Player2>().health = 0;
        }
        if (upRight.collider.gameObject.CompareTag("Breakable"))
        {
            Destroy(upRight.collider.gameObject);
        }
        else if (upRight.collider.gameObject.CompareTag("Player1"))
        {
            FindObjectOfType<Player>().health = 0;
        }
        else if (upRight.collider.gameObject.CompareTag("Player2"))
        {
            FindObjectOfType<Player2>().health = 0;
        }
        if (downLeft.collider.gameObject.CompareTag("Breakable"))
        {
            Destroy(downLeft.collider.gameObject);
        }
        else if (downLeft.collider.gameObject.CompareTag("Player1"))
        {
            FindObjectOfType<Player>().health = 0;
        }
        else if (downLeft.collider.gameObject.CompareTag("Player2"))
        {
            FindObjectOfType<Player2>().health = 0;
        }
        if (downRight.collider.gameObject.CompareTag("Breakable"))
        {
            Destroy(downRight.collider.gameObject);
        }
        else if (downRight.collider.gameObject.CompareTag("Player1"))
        {
            FindObjectOfType<Player>().health = 0;
        }
        else if (downRight.collider.gameObject.CompareTag("Player2"))
        {
            FindObjectOfType<Player2>().health = 0;
        }
    }
}
