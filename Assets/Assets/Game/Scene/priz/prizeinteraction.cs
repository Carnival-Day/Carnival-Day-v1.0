using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prizeinteraction : MonoBehaviour
{
    bool withinRange = false;
    public GameObject upgradePanel;

    // This function is called when another collider enters this object's collider
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            withinRange = true;
        }
    }

    // This function is called when another collider exits this object's collider
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            withinRange = false;
            Debug.Log("Player left the upgrade zone.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if within range and the E key is pressed
        if (withinRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("player opened menu.");
            upgradePanel.SetActive(true); // Activate the upgrade panel
        }
    }
}
