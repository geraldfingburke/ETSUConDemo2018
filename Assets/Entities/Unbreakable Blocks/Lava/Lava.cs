using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

    public GameObject lava;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player1") || col.CompareTag("Player2"))
        {
            Destroy(col.gameObject);

            //TODO
            /**
             * Add health check
             * add speading left and right?
             * Maybe create invinsibilty 
             */
        }

        
    }

    void Update ()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -1f), Vector2.down, 0.05f);
        if (hit.collider == null || hit.collider.CompareTag("Player1") || hit.collider.CompareTag("Player2"))
        {
            Instantiate(lava, transform.position + Vector3.down, Quaternion.identity);
        }
    }
}
