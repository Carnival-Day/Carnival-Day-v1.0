using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ScoreManager : MonoBehaviour//, IDataPersistence
{

    // score is accessible outside ScoreManager
    public static int score;
    [HideInInspector] public static int scoreToReach;

    // private GameData gameData;
    void Start()
    {

    }
    // private static int scoremanagercurrency = 0;
    // public void LoadData(GameData data)
    // {
    //     ScoreManager.scoremanagercurrency = data.currency;
    // }

    // public void SaveData(ref GameData data)
    // {
    //     data.currency = ScoreManager.scoremanagercurrency;
    // }
    // add amount to score depending on hit moles
    // +=1 for mole hit
    // +=5 for hatmole hit
    public static void AddScore(int amount)
    {
        score += amount;
        // scoremanagercurrency += score;
        // DataPersistenceManager.Instance.SaveGame();
        // Debug.Log("Current score: " + score);
        UIManager.instance.UpdateUI(score, scoreToReach);
        //THis is gonna be called miniGame1Score
        //Debug.Log("Current score: " + playerData.miniGame1Score);
    }

    // return score 
    public static int ReadScore()
    {

        return score;
    }





}
