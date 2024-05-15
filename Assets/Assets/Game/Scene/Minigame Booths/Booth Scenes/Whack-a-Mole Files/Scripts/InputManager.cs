using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class InputManager : MonoBehaviour
{

    void Update()
    {
        // if left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {

            // ray is shot in the direction from the camera to mouse point location 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            RaycastHit hit;


            // physics check to see if ray hit mole object
            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.tag == "Mole")
                {
                    // hitting a gameObject with Mole tag will give access to its MoleBehavior Script
                    MoleBehavior mole = hit.collider.gameObject.GetComponent<MoleBehavior>();
                    // turn off collider
                    mole.SwitchCollider(0);

                    // animator will trigger GetHit animation with "hit" parameter
                    mole.anim.SetTrigger("hit");

                    //Debug.Log(hit.collider.gameObject + " got hit");
                }


            }
        }
    }
}
