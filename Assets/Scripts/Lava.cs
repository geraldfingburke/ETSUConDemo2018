using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

    public GameObject lava;
    public GameObject particles;
    private AudioSource audioSource;

    void OnTriggerEnter2D(Collider2D col)
    {
        audioSource.Play();
        if (GetComponent<LavaFloor>())
        {
            Instantiate(particles, transform.position + new Vector3(0, 1, -15), Quaternion.identity);
        } else
        {
            Instantiate(particles, transform.position + new Vector3(0, 0, -15), Quaternion.identity);
        }
        col.GetComponent<Player>().health = 0;
    }

    void Start ()
    {
        InvokeRepeating("LavaFlow", 0.5f, 0.5f);
        audioSource = GetComponent<AudioSource>();

    }

    void LavaFlow ()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -1f), Vector2.down, 0.05f);
        if (hit.collider == null || hit.collider.CompareTag("Player1") || hit.collider.CompareTag("Player2"))
        {
            Instantiate(lava, transform.position + Vector3.down, Quaternion.identity);
        }
    }
}
