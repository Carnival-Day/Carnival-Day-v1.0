using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleBehavior : MonoBehaviour
{
  
    Collider col;

    // default hitPoint amount required to destroy mole on hit
    public int hitPoints = 1;

    public int score = 1;

    // myParent is hole where mole gets spawned in
    [HideInInspector] public GameObject myParent;

    // allows animations to be triggered in other scripts
    [HideInInspector] public Animator anim;

    void Start()
    {
        // retrieve Animator of gameObject
        anim = GetComponent<Animator>();

        // retrieve the Collider of gameObject and disable it at Start
        col = GetComponent<Collider>();
        col.enabled = false;

    }

    public void DestroyObj()
    {
        // destroy Mole when function is called
        myParent.GetComponent<HoleBehavior>().hasMole = false;
        Destroy(gameObject);
    }

    public void SwitchCollider( int num )
    {
        // if num is any int other than 0, enable the collider
        // ComeUp animation will enable collider at frame 15 (num = 1)
        // ComeDown animation will disable collider at frame 15 (num = 0)
        col.enabled = (num == 0) ? false : true;
    }

    // FOR POINTS
    public void GotHit()
    {
        // mole = 1 hit required to destroy
        // hat mole = 2 hits required to destroy
        // each mouse click on gameObject deducts 1 hitPoint

        hitPoints--;

        if ( hitPoints > 0 )
        {
            // user can still hit mole collider until hitPoints = 0
            col.enabled = true;
        } 
        else
        {
            // if hitPoints = 0, destroy mole
            // reset hole before destroying gameObject to allow it to spawn new mole after destruction

            myParent.GetComponent<HoleBehavior>().hasMole = false;

            ScoreManager.AddScore(score);

            Destroy(gameObject);
        }

        
    }

}
