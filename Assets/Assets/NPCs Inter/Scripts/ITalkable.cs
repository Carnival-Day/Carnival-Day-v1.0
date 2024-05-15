using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// By: Triet Nguyen
// Interface for objects that can be talked to
public interface ITalkable
{
    // Method to initiate a conversation with the object
    void Talk(DialogueText dialogueText);
}
