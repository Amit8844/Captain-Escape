using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOver : MonoBehaviour
{
     

     public static bool nextLevel;
     public GameObject nextLevelPanel;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement> () != null)
        {
            nextLevel = true;
                 nextLevelPanel.SetActive(true);
        }
    }
}
