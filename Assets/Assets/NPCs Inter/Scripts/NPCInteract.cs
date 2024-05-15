using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Re-edited by: Laika Alefante
// NPCInteract abstract class implements IInteractable interface and provides base functionality for NPC interaction
public abstract class NPCInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private SpriteRenderer _interactSprite;
    [SerializeField] private AudioClip dialogueAudioClip; // Audio clip to play when interacting with the NPC

    private GameObject _player;
    private const float INTERACT_DISTANCE = 3f; // Adjust as needed
    private AudioSource audioSource; // Reference to the AudioSource component

    // Start method initializes player reference and gets the AudioSource component
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
        if (audioSource && dialogueAudioClip)
        {
            audioSource.clip = dialogueAudioClip;
        }
    }

    // Update method checks for player interaction and updates interaction sprite visibility
    private void Update()
    {
        // Check if left mouse button was pressed and the player is within interact distance
        if (Mouse.current.leftButton.wasPressedThisFrame && IsWithinInteractDistance())
        {
            Interact(); // Call abstract Interact method
        }

        // Update interaction sprite visibility based on player's distance
        UpdateInteractionSpriteVisibility();
    }

    // Abstract Interact method to be implemented by child classes
    public abstract void Interact();

    // Check if the player is within interact distance
    private bool IsWithinInteractDistance()
    {
        // Calculate distance between player and NPC in 2D space
        float distance = Vector2.Distance(_player.transform.position, transform.position);
        return distance < INTERACT_DISTANCE;
    }

    // Update the visibility of the interaction sprite based on player's distance
    private void UpdateInteractionSpriteVisibility()
    {
        if (_interactSprite.gameObject.activeSelf && !IsWithinInteractDistance())
        {
            // Turn off interaction sprite if player is not within interact distance
            _interactSprite.gameObject.SetActive(false);
        }
        else if (!_interactSprite.gameObject.activeSelf && IsWithinInteractDistance())
        {
            // Turn on interaction sprite if player is within interact distance
            _interactSprite.gameObject.SetActive(true);
        }
    }

    // Play the dialogue audio clip
    protected void PlayDialogueAudio()
    {
        if (audioSource && dialogueAudioClip)
        {
            audioSource.Play();
        }
    }
}
