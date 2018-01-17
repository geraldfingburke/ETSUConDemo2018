using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {
    #region Variables
    [Header("The Lava Object")]
    public GameObject lava;

    private GameObject lavaClone;
    private float timeToDestroy = 5f;
    #endregion
    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case ("Player1"):
                    col.gameObject.GetComponent<Player>().health = 0;
                    break;

            case ("Player2"):
                    col.gameObject.GetComponent<Player2>().health = 0;
                    break;

            //TODO
            /**
             * add speading left and right?
             * Maybe create invinsibilty 
             */
        }
    }

    void Start ()
    {
        InvokeRepeating("LavaFlow", 0.1f, 0.1f);
    }

    private void Update()
    {
        if (Time.time > timeToDestroy)
        {
            timeToDestroy = Time.time + 1f;
           // Destroy(gameObject);
        }
    }

    void LavaFlow ()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -1f), Vector2.down, 0.05f);
        if (hit.collider == null || hit.collider.CompareTag("Player1") || hit.collider.CompareTag("Player2"))
        {
            lavaClone = Instantiate(lava, transform.position + Vector3.down, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "LavaDestroyer")
        {
            Destroy(lavaClone);
        }
    }
}
