using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NPCNameText; // Reference to the TextMeshProUGUI for NPC name display
    [SerializeField] private TextMeshProUGUI NPCDialogueText; // Reference to the TextMeshProUGUI for NPC dialogue display
    [SerializeField] private float typeSpeed = 10; // Speed at which dialogue is typed

    private Queue<string> paragraphs = new Queue<string>(); // Queue to store dialogue paragraphs

    private bool conversationEnded; // Flag indicating if conversation has ended
    private bool isTyping; // Flag indicating if dialogue is currently being typed

    private string p; // Current paragraph being displayed

    private Coroutine typeDialogueCoroutine; // Coroutine for typing dialogue

    private const string HTML_ALPHA = "<color=#00000000>"; // HTML tag for transparent color
    private const float MAX_TYPE_TIME = 0.1f; // Maximum time per character during typing

    // Display the next paragraph of dialogue
    public void DisplayNextParagraph(DialogueText dialogueText)
    {
        // If no paragraphs in queue
        if (paragraphs.Count == 0)
        {
            // If conversation hasn't ended, start new conversation
            if (!conversationEnded)
            {
                StartConversation(dialogueText);
            }
            // If conversation has ended and not typing, end conversation
            else if (conversationEnded && !isTyping)
            {
                EndConversation();
                return;
            }
        }
        // If there's a paragraph in queue and not typing, start typing
        if (!isTyping)
        {
            p = paragraphs.Dequeue();
            typeDialogueCoroutine = StartCoroutine(TypeDialogueText(p));
        }
        // If conversation is typing, finish paragraph early
        else
        {
            FinishParagraphEarly();
        }

        // Update conversation ended flag
        if (paragraphs.Count == 0)
        {
            conversationEnded = true;
        }
    }

    // Start a new conversation
    private void StartConversation(DialogueText dialogueText)
    {
        // Activate game object
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        // Update NPC name
        NPCNameText.text = dialogueText.speakerName;

        // Add dialogue paragraphs to queue
        for (int i = 0; i < dialogueText.paragraphs.Length; i++)
        {
            paragraphs.Enqueue(dialogueText.paragraphs[i]);
        }
    }

    // End the current conversation
    private void EndConversation()
    {
        // Clear dialogue queue
        paragraphs.Clear();
        // Reset conversation ended flag
        conversationEnded = false;
        // Deactivate game object
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }

    // Coroutine to type out dialogue text
    private IEnumerator TypeDialogueText(string p)
    {
        isTyping = true;
        NPCDialogueText.text = "";

        string originalText = p;
        string displayedText = "";
        int alphaIndex = 0;

        foreach (char c in p.ToCharArray())
        {
            alphaIndex++;
            NPCDialogueText.text = originalText;

            displayedText = NPCDialogueText.text.Insert(alphaIndex, HTML_ALPHA);
            NPCDialogueText.text = displayedText;

            yield return new WaitForSeconds(MAX_TYPE_TIME / typeSpeed);
        }

        isTyping = false;
    }

    // Finish typing the current paragraph early
    private void FinishParagraphEarly()
    {
        // Stop typing coroutine
        StopCoroutine(typeDialogueCoroutine);
        // Display remaining text immediately
        NPCDialogueText.text = p;
        // Update typing flag
        isTyping = false;
    }
}
