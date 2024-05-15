using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Re-edited By: Triet Nguyen
// CreateAssetMenu attribute allows creating instances of this scriptable object from the Unity editor
[CreateAssetMenu(menuName = "Dialogue/New Dialogue Container")]

// DialogueText class represents a container for dialogue text
public class DialogueText : ScriptableObject
{
    // Name of the speaker for the dialogue
    public string speakerName;

    // Array of paragraphs containing the dialogue text
    [TextArea(5, 10)]
    public string[] paragraphs;

    // Language of the dialogue text
    public string language;

    // Method to format the dialogue text with speaker's name and language
    public string FormatDialogue()
    {
        // Example implementation: concatenate speaker's name and language with dialogue paragraphs
        string formattedDialogue = "Speaker: " + speakerName + "\n";
        foreach (string paragraph in paragraphs)
        {
            formattedDialogue += "(" + language + ") " + paragraph + "\n";
        }
        return formattedDialogue;
    }
}
