using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Re-edited by: Laika Alefante
// NPC1 class inherits from NPCInteract and implements ITalkable interface
public class NPC1 : NPCInteract, ITalkable
{
    // Serialized field for the DialogueText asset
    [SerializeField] private DialogueText dialogueText;

    // Serialized field for the DialogueController component
    [SerializeField] private DialogueController dialogueController;

    // Flag to determine if the NPC can talk
    private bool canTalk = true;

    // Overridden Interact method from NPCInteract
    public override void Interact()
    {
        // Check if the NPC can talk
        if (canTalk)
        {
            // Call Talk method with dialogueText as parameter
            Talk(dialogueText);
        }
        else
        {
            // Display a message indicating the NPC is not available for conversation
            Debug.Log("Sorry, I'm not available for conversation right now.");
        }
    }

    // Implementation of Talk method from ITalkable interface
    public void Talk(DialogueText dialogueText)
    {
        // Start conversation by displaying the first paragraph of dialogue
        dialogueController.DisplayNextParagraph(dialogueText);

        // Optionally, you can add more dialogue logic here, such as branching dialogue paths
        // Example: if (dialogueText.HasBranchingPath) { HandleBranchingDialogue(); }
    }

    // Method to handle branching dialogue paths
    private void HandleBranchingDialogue()
    {
        // Implement branching dialogue logic here
        // Example: dialogueController.DisplayBranchingOptions(dialogueText.BranchingOptions);
    }

    // Method to disable NPC interaction temporarily
    public void DisableInteraction()
    {
        canTalk = false;
    }

    // Method to enable NPC interaction
    public void EnableInteraction()
    {
        canTalk = true;
    }

    // Method to check if NPC is currently available for interaction
    public bool IsAvailableForInteraction()
    {
        return canTalk;
    }

    // Method to trigger an event after the conversation ends
    private void OnConversationEnd()
    {
        // Implement any post-conversation events here
        // Example: questManager.CompleteQuest(questID);
    }
}
