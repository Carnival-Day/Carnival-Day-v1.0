using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class BalloonManager : MonoBehaviour, IDataPersistence
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI finalScoreText;
    public float time = 60f;
    public float currentTime = 0f; // DONT TOUCH IN INSPECTOR
    public static int score {get; private set;}
    private GameData gameData;
    public int bpOverScene;
    public GameObject gameOverPanel;
    private bool hasScoreBeenAdded;

    private void Start()
    {
        NewGame();
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timeText.text = currentTime.ToString("f2");
        }
        else { GameOver(); } 
        
    }

    public void NewGame()
    {
        currentTime = time;
        score = 0;
        updateScoreText();
        hasScoreBeenAdded = false;
    }

    public void adjustScore(int points)
    {
        score += points;
        Debug.Log("Current score: " + score);
        updateScoreText();
        
    }

    private void updateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    private int currency = 0;
    public void LoadData(GameData data)
    {
        this.currency = data.currency;
    }

    public void SaveData(ref GameData data)
    {
        data.currency = this.currency;
    }

    void GameOver()
    {
        
        finalScoreText.text = "Final Score: " + score;
        gameOverPanel.SetActive(true); 
        
        if (!hasScoreBeenAdded)
        {
            Debug.Log("currency before game over: " + currency);
            currency += score;
            Debug.Log("currency after game over: " + currency);
            hasScoreBeenAdded = true;
        }
        DataPersistenceManager.Instance.SaveGame();
        
    }

    void OnGUI()
    {
        if (gameOverPanel.activeSelf && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            SceneManager.LoadScene(bpOverScene);
        }
    }
}
