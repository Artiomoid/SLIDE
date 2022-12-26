using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class PlayerManager : MonoBehaviour
{
    public LeaderBoard leaderboard;

    // Start is called before the first frame update
    void Start()
    {
        leaderboard = GetComponent<LeaderBoard>();
    }

    // Update is called once per frame
    public IEnumerator PlayerDied(int score){


      yield return new WaitForSeconds(1);
        Debug.Log("Player Died: " + score);
      FindObjectOfType<GameManager>().StopGame();
        yield return leaderboard.SumbitScoreRoutine(score);
     

    }
}
