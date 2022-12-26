using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBoostUpdate : MonoBehaviour
{
    public Text SpeedBoostText;
    public PlayerMovement playerSpeed;



   void Update()
    {
           if (!FindObjectOfType<GameManager>().gameOver)
        {
           
            SpeedBoostText.text = "SpeedBoost:"+ (playerSpeed.forwardSpeed - 3000);

    
            
                
            }
            
        }
}
