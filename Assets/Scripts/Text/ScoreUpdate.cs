using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour {

    public Text score;
    public Transform player;
    public int maxium;

 
   // public highScore high;
    public PlayerMovement movement;
  
     
    

	// Update score text

	void Update ()
    {
        
        if (!FindObjectOfType<GameManager>().gameOver)
        {
           
            score.text =  player.position.z.ToString("0");
            if(maxium < player.position.z)
            {
                
                PlayerPrefs.GetInt("score", maxium);
                maxium = (int)player.position.z;
                

               // playFabManager.SendLeaderboard(maxium);
           //     high.ShowHighestScore(maxium);
               

            }

            
        }
	}
}
