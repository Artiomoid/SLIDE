using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class leaderboardTable : MonoBehaviour
{
   int leaderboardID = 9818;

    public GameObject rowPrefab;
    public Transform rowsParent;

   public IEnumerator FetchTopHighscoresRoutine(){
    bool done = false;
    LootLockerSDKManager.GetScoreListMain(leaderboardID, 20, 0 ,(response) => 
    {
          if(response.success){
          

            LootLockerLeaderboardMember[] members = response.items;


            for(int i = 0; i < members.Length; i++)
            {
               string tempPlayerNames = "Names\n";
          string tempPlayerScores = "";
              GameObject newGo = Instantiate(rowPrefab, rowsParent);
              TextMeshProUGUI[] texts = newGo.GetComponentsInChildren<TextMeshProUGUI>();
              texts[1].text = "";
                tempPlayerNames  = members[i].rank + ". ";
                 if(members[i].player.name != "")
                    {
                        tempPlayerNames += members[i].player.name;
                    }
                    else
                    {
                        tempPlayerNames += members[i].player.id;
                    }
                tempPlayerScores += members[i].score + "\n";
                
                    tempPlayerNames += "\n";

                  texts[0].text = tempPlayerNames;
                  texts[1].text = tempPlayerScores;
            }
            done = true;
         
          }
          else{
            Debug.Log("Failed" + response.Error);
            done = true;
          }
    });
    yield return new WaitWhile(()=> done == false);
   }
}
