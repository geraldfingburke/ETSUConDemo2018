using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Projectile : MonoBehaviour {

    public AudioClip clip;
    public GameObject particles;


    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.CompareTag("Breakable"))
        {
            AudioSource.PlayClipAtPoint(clip, new Vector3(0, 0, -15));
            Instantiate(particles, transform.position + new Vector3(0,0,-15), Quaternion.identity);
            Destroy(gameObject);
        } else if (col.CompareTag("Player1"))
        {
            col.GetComponent<Player>().health--;
            Destroy(this.gameObject);
        } else if (col.CompareTag("Explosive"))
        {
            col.GetComponent<Explosive>().Explode();
            Destroy(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}
