using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

       [SerializeField] private float damage;  

       
    
   

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Player")
        {

            collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(this.gameObject);
           
                 
            
        }
        if(collision.tag == "Walls")
        {
            
            Destroy(gameObject);
            
        }
         if (collision.tag == "Pushable")
        {
            
              Destroy(gameObject);
             
        }
    }
    
}
