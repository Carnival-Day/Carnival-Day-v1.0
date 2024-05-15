using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour, IDataPersistence
{
    // timer 
    int playtime = 20;
    int seconds, minutes;

    int currLevel = 1;
    int baseScore = 50;
    int scoreToReach;
    public int wamOverScene;
    public GameObject gameOverPanel;

    private GameData gameData;
    private int currency = 0;
    public TMP_Text scoreText;

    public void LoadData(GameData data)
    {
        this.currency = data.currency;
    }

    public void SaveData(ref GameData data)
    {
        data.currency = this.currency;
    }
    private bool hasScoreBeenAdded;

    void Start()
    {
        // Turn off gameOverPanel.
        gameOverPanel.SetActive(false);
        // set target score and call IEnumerator timer
        hasScoreBeenAdded = false;
        scoreToReach = currLevel * baseScore;
        ScoreManager.scoreToReach = scoreToReach;
        UIManager.instance.UpdateUI(0, scoreToReach);
        StartCoroutine("PlayTimer");
        
    }

    IEnumerator PlayTimer()
    {
        while(playtime > 0)
        {
            // wait one second before starting timer after while loop is entered
            yield return new WaitForSeconds(1);
            playtime--;
            seconds = playtime % 60;
            minutes = playtime / 60 % 60;

            //update ui with timer
            UIManager.instance.UpdateTime(minutes, seconds);
       
        }
        yield return new WaitForSeconds(1);
        Debug.Log("Timer has ended");
        // fill in win or lose condition later
        GameOver();
    }

    void GameOver()
    {
        scoreText.text = "Your Score: " + ScoreHolder.score.ToString();
        gameOverPanel.SetActive(true); 

        if (!hasScoreBeenAdded)
        {
            Debug.Log("WAM: currency before game over: " + currency);
            currency += (int)ScoreManager.ReadScore();
            Debug.Log("WAM: currency after game over: " + currency);
            hasScoreBeenAdded = true;
            DataPersistenceManager.Instance.SaveGame();

        }
        ScoreHolder.score = ScoreManager.ReadScore();
        resetMinigame();
    }

    void resetMinigame()
    {
        ScoreManager.score = 0;
        playtime = 20;
        StartCoroutine("PlayTimer");
    }

    void OnGUI()
    {
        if (gameOverPanel.activeSelf && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            SceneManager.LoadScene(wamOverScene);
        }
    }
    
}
