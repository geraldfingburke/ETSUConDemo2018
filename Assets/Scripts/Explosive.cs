using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour {

    public Projectile projectile;
    public float projectileSpeed;
    public ParticleSystem particles;

    private Animator anim;
    private AudioSource audioSource;

    void Start () {
        Invoke("Explode", Random.Range(10, 20));
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
	}
	
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Projectile"))
        {
            Explode();
        }
    }

    public void Explode ()
    {
        particles.Play();
        anim.SetTrigger("explode");
        audioSource.Play();
        Destroy(gameObject, 1);
    }

    void OnParticleEnter (GameObject other)
    {
        Invoke("Explode", 1);
    }
}

