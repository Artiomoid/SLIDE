using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public bool gameOver = false;
    public float restartLevelDelay = 2f;
    public Color32 gameOverColor = new Color32(249, 92, 64, 1);
    public GameObject fadeOutPanel;
    public GameObject fadeInPanel;
    public GameObject youWonPanel;
    public GameObject StopPanel;
   
    public Text score;
    public bool paused;
    

    public void Start()
    {
        fadeInPanel.SetActive(true);
        //level.text = "Level " + SceneManager.GetActiveScene().buildIndex;
    }

    public void Update()
    {

        // Pause

        if (Input.GetKeyDown("p"))
        {
            if (Time.timeScale != 0)
            {
                StopPanel.SetActive(true);
                paused = true;
                 Time.timeScale = 0;
            }
            else
            {
                StopPanel.SetActive(false);
                paused = false;
                Time.timeScale = 1; // unpause

            }
        }

    }


    public void CompleteLevel()
    {
        if (!gameOver)
        {
            score.text = "500";
            gameOver = true;
            youWonPanel.SetActive(true);
            FindObjectOfType<PlayerMovement>().enabled = false; // stop movement of player
            Invoke("NextLevel", restartLevelDelay);
        }
    }

    public void StopGame()
    {
        Debug.Log("Called");
        FindObjectOfType<PlayerMovement>().enabled = false; // stop movement of player
        FindObjectOfType<Camera>().backgroundColor = gameOverColor; // turn background to red
        RenderSettings.fogColor = gameOverColor; // turn fog to red
        StopPanel.SetActive(true);
        Time.timeScale = 0;
         
       
        

    }

    public void EndGame(){
        fadeOutPanel.SetActive(true);
        if (!gameOver)
        {
            gameOver = true;
            
            
            Invoke("Restart", restartLevelDelay);
        }
        
    }

    public void RestartButtonClicked()
    {
        Debug.Log("Restart");
        fadeOutPanel.SetActive(true);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

     public void MenuButtonClicked()
    {
         Debug.Log("Menu");
        fadeOutPanel.SetActive(true);
       SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }


    public void NextLevel()
    {
        fadeOutPanel.SetActive(true);
        Invoke("LoadNextScreen", 1);
    }

    private void LoadNextScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
