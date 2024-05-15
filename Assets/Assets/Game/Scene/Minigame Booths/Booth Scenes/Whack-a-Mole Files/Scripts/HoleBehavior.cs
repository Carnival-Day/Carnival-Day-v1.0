using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HoleBehavior : MonoBehaviour
{

    // set up public GameObject array to contain moles
    public GameObject[] moles;

    // check to avoid double spawn of moles in 1 hole
    public bool hasMole;

    void Start()
    {
        // if hole is empty at game start, a mole will randomly spawn from hole
        if ( !hasMole )
        {
            
            Invoke("Spawn", Random.Range(0f, 10f));
        }

        
    }


    void Spawn()
    {

        if ( !hasMole )
        {
            int num = Random.Range(0, moles.Length);

            GameObject mole = Instantiate(moles[num], transform.position, Quaternion.identity) as GameObject;

            // allows MoleBehavior and HoleBehavior script to communicate over presence of mole in hole
            mole.GetComponent<MoleBehavior>().myParent = this.gameObject;

            // since mole was spawned in this hole, set boolean to true
            hasMole = true;
        }

        // continuously spawn moles from an interval of 3-14 seconds
        Invoke("Spawn", Random.Range(3f, 14f));

    }
}
