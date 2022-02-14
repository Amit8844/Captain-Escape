using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHeaalth;
    public float currentHealth {get; private set;}

    private bool dead;

    public static bool gameOver;

    public GameObject gameOverPanel;



    void Awake() 
    {
        currentHealth = startingHeaalth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHeaalth);

        if (currentHealth > 0)
        {
            
        }
        else
        {
            if(!dead)
            {
                 GetComponent<PlayerMovement>().enabled = false;
                 dead = true;
                  gameOver = true;
                 gameOverPanel.SetActive(true);
            }
            
        }
    }
   
}
