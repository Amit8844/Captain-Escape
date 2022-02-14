using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

       [SerializeField] private float damage;

       public GameObject Effect;

    public SpriteRenderer sr;
    public TrailRenderer tr;

    public Rigidbody2D rb;

       
    
   

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player")
        {

            collision.GetComponent<Health>().TakeDamage(damage);
            PlayEffect();



        }
        if(collision.tag == "Walls")
        {

            PlayEffect();
            
        }
         
    }

    private void PlayEffect()
    {
        sr.enabled = false;
        tr.enabled = false;
        rb.velocity = Vector2.zero;

        Effect.SetActive(true);

        Effect.transform.position = transform.position; 
        ParticleSystem[] effects = Effect.transform.GetComponentsInChildren<ParticleSystem>();

        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].Play();
        }

        StartCoroutine(DestroyBullet());
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(0.7f) ;
        Destroy(this.gameObject);
    }
}
