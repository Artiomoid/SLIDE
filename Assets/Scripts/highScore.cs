using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
     public Text high;
    
 
    void Awake()
    {
        high = GetComponent<Text>();
    }

     public void ShowHighestScore(float maxium){
    high.text = "Best Score:" + maxium.ToString();

   }
}
