using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;

    private void Awake()
    {
        instance = this;
    }

    public enum Scene
    {
        Game,
        WhackaMole,
        BalloonPop
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    // Call to Load whack-a-mole
    public void LoadMinigame1()
    {
        SceneManager.LoadScene(Scene.WhackaMole.ToString());
    }

    // Call to Load pop the balloons
    public void LoadMinigame2()
    {
        SceneManager.LoadScene(Scene.BalloonPop.ToString());
    }

    // Call to Load map
    public void LoadMap()
    {
        SceneManager.LoadScene(Scene.Game.ToString());
    }
}
