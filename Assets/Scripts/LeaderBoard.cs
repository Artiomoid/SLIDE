using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;


public class LeaderBoard : MonoBehaviour
{
    int leaderboardID = 9818;
  
   public IEnumerator SumbitScoreRoutine(int scoreToUpload){
    bool done = false;
    string playerID = PlayerPrefs.GetString("PlayerID");
    LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardID, (response) => {
        if(response.success){
            Debug.Log("Successfully uploaded score");
            done = true;
        }
        else{
            Debug.Log("Failed" + response.Error);
            done = true;
        }
   });
   yield return new WaitWhile(() => done = false);
   }

   
}
