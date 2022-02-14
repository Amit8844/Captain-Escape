using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret2Script : MonoBehaviour
{
     public float Range;

    public Transform Target;

    bool Detected = false;

    Vector2 Direction;

    public GameObject Laser;

    public GameObject Bullet;

    public float FireRate;

    float nextTimeToShoot = 0;
    public Transform ShootPoint;

    public float Force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position;

        Direction = targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position,Direction,Range);

        if(rayInfo)
        {
            if(rayInfo.collider.gameObject.tag == "Player")
            {
                if(Detected == false)
                {
                    Detected = true;
                }
            }

            else if(Detected == true)
            {
               
                    Detected = false;
               
            }
        }
        if(Detected)
        {
            Laser.transform.up = Direction;
            if(Time.time > nextTimeToShoot)
            {
                nextTimeToShoot = Time.time + 1 /FireRate;
                shoot();
            }
        }
    }

    void shoot()
    {
        GameObject BulletIns = Instantiate(Bullet,ShootPoint.position,Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }

     void OnDrawGizmosSelected() 
     {
        Gizmos.DrawWireSphere(transform.position, Range);
     }
     
}
