using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashMovement : MonoBehaviour
{
    
     public float dashSpeed = 200000;

    public Rigidbody2D rg;

    bool dash = true;
    int dashCooldown = 80;

    void FixedUpdate()
    {
        if (dashCooldown == 0)
        {
            dash = true;
        }
        else
        {
            dashCooldown--;
        }

        rg.velocity = Vector2.zero;

        if (dash && Input.GetKey(KeyCode.Space))
        {
            Vector2 mouseDirection = (Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2)).normalized;
            rg.AddForce(mouseDirection * dashSpeed * Time.fixedDeltaTime);
            dash = false;
            dashCooldown = 80;
     
        } 
    }


}
