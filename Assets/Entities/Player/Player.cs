using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private int facing;

    public float moveSpeed;
    public float jumpHeight;

	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Horizontal") >= 0.05f)
        {
            Debug.DrawRay(transform.position, Vector3.right, Color.red, 10f);
            this.GetComponent<SpriteRenderer>().flipX = false;
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0), Vector2.right, 0.05f);
            if (hit.collider == null)
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                Debug.Log("clear");
            } else
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
        if (Input.GetButtonDown("Attack"))
        {
            if (facing == 0)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3 (0.5f, 0), Vector2.right, 1);
                if (hit.collider.CompareTag("Breakable"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }else if (facing == 1)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3 (-0.5f, 0), Vector2.left, 1);
                if (hit.collider.CompareTag("Breakable"))
                {
                    Destroy(hit.collider.gameObject);
                }
            } else if (facing == 2)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3 (0, 0.5f), Vector2.up, 0.5f);
                if (hit.collider.CompareTag("Breakable"))
                {
                    Destroy(hit.collider.gameObject);
                }
            } else if (facing == 3)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3 (0, -0.5f), Vector2.down, 0.5f);
                if (hit.collider.CompareTag("Breakable"))
                {
                    Destroy(hit.collider.gameObject);
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
	}
}
