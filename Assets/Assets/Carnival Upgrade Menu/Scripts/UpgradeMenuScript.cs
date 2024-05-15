using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Worked on by Derick Pan
// The upgrade menu script is responsible for unlocking and loading mini-games
public class UpgradeMenuScript : MonoBehaviour, IDataPersistence
{
    public GameObject upgradeMenu;

    public GameObject bpButton;
    public GameObject wamButton;

    private bool whackamole = false;
    private bool balloonpop = false;
    private int currency =0;
    private GameData gameData;
    void Start()
    {
        
        if (whackamole)
        {
            wamButton.SetActive(false);  // Disable the Whack-a-Mole button if already purchased
        }
        if (balloonpop)
        {
            bpButton.SetActive(false);  // Disable the Balloon Pop button if already purchased
        }
    }
    public void LoadData(GameData data)
    {
        this.whackamole = data.whackamole;
        this.balloonpop = data.balloonpop;
        this.currency = data.currency;
    }

    public void SaveData(ref GameData data)
    {
        data.whackamole = this.whackamole;
        data.balloonpop = this.balloonpop;
        data.currency = this.currency; 
    }

    public bool CheckPrerequisitesAndUnlock(string miniGame)
    {
        if (currency >= 500)
        {
            currency -= 500;
            DataPersistenceManager.Instance.SaveGame();
            switch (miniGame)
            {
                case "MiniGame1":
                    whackamole = true;
                    DataPersistenceManager.Instance.SaveGame();
                    break;
                case "MiniGame2":
                    balloonpop = true;
                    DataPersistenceManager.Instance.SaveGame();
                    break;

            }
            return true;
        }
        else
        {
            Debug.Log("UpgradeMenuScript.cs: Not enough currency to unlock " + miniGame);
            return false;
        }
    }

   

    public void LoadMiniGame1()
    {
        Debug.Log("UpgradeMenuScript.cs: MiniGame1 Attempt to Unlock");
        if (CheckPrerequisitesAndUnlock("MiniGame1"))
        {
            Debug.Log("UpgradeMenuScript.cs: MiniGame1 Unlocked");
            DataPersistenceManager.Instance.SaveGame();
            //SceneManager.LoadScene("MiniGame1Scene");
        }
    }

    public void LoadMiniGame2()
    {
        Debug.Log("UpgradeMenuScript.cs: MiniGame2 Attempt to Unlock");
        if (CheckPrerequisitesAndUnlock("MiniGame2"))
        {
            Debug.Log("UpgradeMenuScript.cs: MiniGame2 Unlocked");
            DataPersistenceManager.Instance.SaveGame();
            //SceneManager.LoadScene("MiniGame2Scene");
            
        }
    }

    public void LoadMiniGame3()
    {
        
        if (CheckPrerequisitesAndUnlock("MiniGame3"))
        {
            //SceneManager.LoadScene("MiniGame3Scene");
        }
    }

    public void LoadESCScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadPrizeBoothScene()
    {
        SceneManager.LoadScene("PrizeBoothScene");
    }

    public void LoadRandomScene()
    {
        SceneManager.LoadScene("RandomScene");
    }
}
