using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    public float fadeOutDuration = 1.0f; // Duration of the fade-out animation in seconds
    public float delayBeforeLoad = 0.5f; // Additional delay before loading the next scene

    // Load the next scene with a fade-out effect
    public void FadeToLevel(int levelIndex)
    {
        // Trigger fade-out animation
        animator.SetTrigger("FadeOut");

        // Start loading the next scene asynchronously after fade-out duration and delay
        StartCoroutine(LoadNextSceneWithDelay(levelIndex));
    }

    // Coroutine to load the next scene asynchronously with a delay
    private IEnumerator LoadNextSceneWithDelay(int levelIndex)
    {
        // Wait for the fade-out animation to complete
        yield return new WaitForSeconds(fadeOutDuration);

        // Wait for an additional delay before loading the next scene
        yield return new WaitForSeconds(delayBeforeLoad);

        // Load the next scene asynchronously
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(levelIndex);

        // Wait until the next scene is fully loaded
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}