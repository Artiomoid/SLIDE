using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighestScore : MonoBehaviour
{


    public Text highestScore;


    void Awake(){

 DontDestroyOnLoad(gameObject);
  highestScore = GetComponent<Text>();

    }


   public void ShowSpeed(float speed){
    highestScore.text = speed.ToString() + "/h";

   }
   
}
