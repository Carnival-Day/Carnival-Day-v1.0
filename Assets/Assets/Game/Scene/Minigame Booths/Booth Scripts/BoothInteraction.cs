using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoothInteraction : MonoBehaviour
{
    bool withinRange;
    public int sceneToLoad;


    void OnTriggerEnter( Collider other )
    {
        if (other.tag == "Player")
        {
            withinRange = true;
        }
    }

    void Update()
    {
        if (withinRange && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
