using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCS : MonoBehaviour
{
    public LevelChanger levelChanger;
    public Scene    sceneName;
    public int sceneNum;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        levelChanger.FadeToLevel(1);
    }

    public void LoadGameLevel(int sceneNum)
    { 
        SceneManager.LoadScene(sceneNum);
    }

}
