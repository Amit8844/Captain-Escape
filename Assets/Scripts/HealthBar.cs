using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   [SerializeField] private Health playerHealth;
   [SerializeField] private Image totalHealthBar;
   [SerializeField] private Image currentHealthBar;

   void Start() 
   {
       totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
   }

   void Update() 
   {
       currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
   }
}
