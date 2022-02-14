using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
     public Text MyscoreText;
     private int ScoreNum;

    // Start is called before the first frame update
    void Start()
    {
        ScoreNum=0;
        MyscoreText.text = " :  " + ScoreNum;
    }

    void OnTriggerEnter2D(Collider2D Gem) 
    {
        if(Gem.tag == "MyGem")
        {
            ScoreNum += 1;
            Destroy(Gem.gameObject);
            MyscoreText.text = " : " +  ScoreNum;
        }
    }

    
}
