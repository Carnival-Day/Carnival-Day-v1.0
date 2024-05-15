using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Done by Vanessa Ramirez
public class MapToggler : MonoBehaviour
{
    // SerializedField allows private fields to be displayed in the Unity Editor
    [SerializeField] private GameObject _map; // The map GameObject to be toggled

    [SerializeField] private KeyCode _toggleKey; // The key used to toggle the map

    // Update is called once per frame
    void Update()
    {
        // Check if the toggle key is pressed down
        if (Input.GetKeyDown(_toggleKey))
        {
            // Toggle the active state of the map GameObject
            _map.SetActive(!_map.activeInHierarchy);
        }
    }
}
