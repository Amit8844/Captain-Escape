using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
   public void LevelOver()
   {
       SceneManager.LoadScene("NextLevel") ;
   }
   public void MainMenue()
   {
       SceneManager.LoadScene("StartScene") ;
   }
}
