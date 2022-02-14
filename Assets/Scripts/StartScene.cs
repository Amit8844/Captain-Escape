using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
   public void StartGame()
   {
       SceneManager.LoadScene("GameScene") ;
   }
   public void Quit()
   {
       Application.Quit();
   }
}
