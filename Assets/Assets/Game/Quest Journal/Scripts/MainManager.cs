using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public List<string> questNames = new List<string>(); // List to store quest names

    // Static reference to the MainManager instance
    public static MainManager mainManager;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Check if there is already an instance of MainManager
        if (mainManager != null)
        {
            // If yes, destroy this instance to enforce the Singleton pattern
            Destroy(gameObject);
        }

        // Set mainManager to this instance
        mainManager = this;

        // Don't destroy this GameObject when loading a new scene
        DontDestroyOnLoad(gameObject);
    }

    // Method to add a quest to the list of quest names
    public void AddQuest(string quest)
    {
        if (!questNames.Contains(quest))
        {
            questNames.Add(quest);
        }
    }

    // Method to remove a quest from the list of quest names
    public void RemoveQuest(string quest)
    {
        if (questNames.Contains(quest))
        {
            questNames.Remove(quest);
        }
    }
}
