using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateInteraction : MonoBehaviour
{
    bool withinRange;
    bool open = true;
    bool close = false;
    public GameObject OpenGateFrontL;
    public GameObject OpenGateFrontR;
    public GameObject OpenGateBackL;
    public GameObject OpenGateBackR;

    public GameObject CloseGateFront;
    public GameObject CloseGateBack;


    void OnTriggerEnter(Collider other)
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
            OpenGateFrontL.SetActive(open);
            OpenGateFrontR.SetActive(open);
            OpenGateBackL.SetActive(open);
            OpenGateBackR.SetActive(open);
          

            CloseGateFront.SetActive(close);
            CloseGateBack.SetActive(close);
        }
    }

}
