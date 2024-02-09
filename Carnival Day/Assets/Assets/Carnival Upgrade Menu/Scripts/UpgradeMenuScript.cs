using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeMenuScript : MonoBehaviour
{
    public void LoadMiniGame1()
    {
        SceneManager.LoadScene("MiniGame1Scene"); //if you change the MiniGame1Scene's name then you will have to change this method to match the name for example if you change the scene's name to MiniGameScene1 so you will have to write that here like SceneManager.LoadScene("MiniGameScene1");
    }

    public void LoadMiniGame2()
    {
        SceneManager.LoadScene("MiniGame2Scene");
    }
    
    public void LoadMiniGame3()
    {
        SceneManager.LoadScene("MiniGame3Scene");
    }
    
    public void LoadESCScene()
    {
        SceneManager.LoadScene("EscScene");
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
