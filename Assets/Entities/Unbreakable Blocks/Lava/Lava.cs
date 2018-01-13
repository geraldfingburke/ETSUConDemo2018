using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

    public GameObject lava;

    void Start ()
    {
        InvokeRepeating("LavaFlow", 0.5f, 0.3f);
    } 
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player1"))
        {
            col.GetComponent<Player>().health = 0;
        } else if (col.CompareTag("Player2")) {
            col.GetComponent<Player2>().health = 0;
        }

        
    }

    void LavaFlow()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -1f), Vector2.down, 0.05f);
        if (hit.collider == null || hit.collider.CompareTag("Player1") || hit.collider.CompareTag("Player2"))
        {
            Instantiate(lava, transform.position + Vector3.down, Quaternion.identity);
        }
    }
}
