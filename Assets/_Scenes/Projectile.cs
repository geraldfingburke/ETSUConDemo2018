using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Projectile : MonoBehaviour {

    public AudioClip clip;
    public GameObject particles;
    public CameraShake shake;

    void Start () {
        shake = FindObjectOfType<CameraShake>();
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        shake.Shake(0.1f, 0.5f);
        if (col.CompareTag("Breakable"))
        {
            AudioSource.PlayClipAtPoint(clip, new Vector3(0, 0, -15));
            Instantiate(particles, transform.position + new Vector3(0,0,-15), Quaternion.identity);
            Destroy(gameObject);
        } else if (col.CompareTag("Player1"))
        {
            if (col.GetComponent<Player>().health > 0) {
                col.GetComponent<Player>().health--;
                Destroy(gameObject);
            }
        } else if (col.CompareTag("Player2")) {
            if (col.GetComponent<Player2>().health > 0) {
                col.GetComponent<Player2>().health--;
                Destroy(gameObject);
            }
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
