using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using Text = UnityEngine.UI.Text;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text scoreText;
    public Text timerText;

    // unity provided function to call UIManager instance and allows us to request UpdateUI()
    void Awake()
    {
        instance = this;

        // start play timer at 1 minute 0 seconds
        UpdateTime(0, 20);
    }


    public void UpdateTime( int min, int sec )
    {
        timerText.text = min.ToString("D2") + ":" + sec.ToString("D2");
    }

    public void UpdateUI(int score, int scoreToReach)
    {
        scoreText.text = "Score: " + score + "/" + scoreToReach;
    }

}
