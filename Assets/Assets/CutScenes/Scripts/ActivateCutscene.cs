using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ActivateCutscene : MonoBehaviour
{
    // Reference to the PlayableDirector component that controls the cutscene
    [SerializeField] private PlayableDirector playableDirector;

    // Called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered the trigger is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // If the collider is the player, start playing the cutscene controlled by the PlayableDirector
            playableDirector.Play();

            // Disable the BoxCollider component attached to this GameObject
            // This prevents the trigger from being activated again until it's enabled
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
