using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField playerNameInputfield;
    public leaderboardTable leaderboardTable;
    public TextMeshProUGUI playerId;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetupRoutine());
        Debug.Log("SetUp");
    }

     IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        yield return leaderboardTable.FetchTopHighscoresRoutine();
    }

     public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInputfield.text, (response) =>
        {
            if(response.success)
            {
                Debug.Log("Succesfully set player name");
            
            }
            else
            {
                Debug.Log("Could not set player name"+response.Error);
            }
        });

        
        
    }

     IEnumerator LoginRoutine()
    {
       
        LootLockerSDKManager.GetPlayerName((response) =>
     {
    if (response.success)
    {
        playerNameInputfield.enabled = false;
        Debug.Log("Recived Named");
          playerId.text = "Player:" + playerNameInputfield.text; 
    } else
    {
          playerNameInputfield.enabled = true;
          Debug.Log("Could not retrieve player name");
           playerId.text = "Player:" + PlayerPrefs.GetString("PlayerID"); 
    }
});

        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
        
            if(response.success)
            {
                Debug.Log("Player was logged in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                Debug.Log("Player ID:"+ PlayerPrefs.GetString("PlayerID"));

                done = true;
            }
            else
            {
                Debug.Log("Could not start session");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
