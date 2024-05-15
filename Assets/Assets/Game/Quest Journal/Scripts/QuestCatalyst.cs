using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// By: Vanessa Ramirez
public class QuestCatalyst : MonoBehaviour
{
    [SerializeField] private string quest; // The name of the quest associated with this catalyst

    private bool questAdded = false; // Flag indicating whether the quest has been added

    // Property to access questAdded flag
    public bool QuestAdded => questAdded;

    // Update is called once per frame
    private void Update()
    {
        // Check if the "Q" key is pressed to interact with the quest
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Perform quest interaction
            InteractWithQuest();
        }
    }

    // Perform interaction with the quest
    public void InteractWithQuest()
    {
        if (!questAdded)
        {
            // Create the quest if not already added
            CreateQuest();
        }
        else
        {
            // Complete the quest if already added
            CompleteQuest();
        }
    }

    // Add the quest to the list of quests
    public void CreateQuest()
    {
        // If quest is not already added and quest name is not null
        if (!questAdded && !string.IsNullOrEmpty(quest))
        {
            // Mark quest as added
            questAdded = true;
            // Add quest to the list of quests in the MainManager
            MainManager.mainManager?.AddQuest(quest);
        }
    }

    // Remove the quest from the list of quests
    public void CompleteQuest()
    {
        // If quest name is not null and quest is in the list of quests
        if (questAdded && !string.IsNullOrEmpty(quest))
        {
            // Remove quest from the list of quests in the MainManager
            MainManager.mainManager?.RemoveQuest(quest);
            // Reset questAdded flag
            questAdded = false;
        }
    }
}
