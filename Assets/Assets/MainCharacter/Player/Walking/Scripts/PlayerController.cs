using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;

//start() load player data, gives a tag, starts a code routine to download data from mongodb
public class PlayerController : MonoBehaviour, IDataPersistence
{
    // References
    public Rigidbody theRB;


    // How fast we move and jump around
    public float moveSpeed;

    // Keep track of character movement
    private Vector2 moveInput;

    // Reference to the animator
    public Animator anim;

    // Flipping the animation
    public SpriteRenderer theSR;

    // Setting for the animator
    public Animator flipAmin;

    // moving backwards and forward animation
    private bool movingBackwards;
    private bool movingForward;

    public float crouchSpeed = 2f; // Speed when crouching
    private bool isCrouching = false;

    // Flag to control walking
    private bool walkingEnabled = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void EnableWalking()
    {
        walkingEnabled = true;
    }

    public void DisableWalking()
    {
        walkingEnabled = false;
    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    
        if (!walkingEnabled)
        {
            // If walking is disabled, return without updating movement
            return;
        }

        // Check if the player wants to crouch
        if (Input.GetKey(KeyCode.C))
        {
            isCrouching = true;
            moveSpeed = crouchSpeed; // Set move speed to crouch speed
        }
        else
        {
            isCrouching = false;
            moveSpeed = 5f; // Reset move speed
        }
        // Walking input
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        // Walking speed
        theRB.velocity = new Vector3(moveInput.x * moveSpeed, theRB.velocity.y, moveInput.y * moveSpeed);
        anim.SetFloat("moveSpeed", theRB.velocity.magnitude);

        // Make the character flip from right to left
        if (!theSR.flipX && moveInput.x < 0)
        {
            theSR.flipX = true;
            flipAmin.SetTrigger("Flip");
        }
        else if (theSR.flipX && moveInput.x > 0)
        {
            theSR.flipX = false;
            flipAmin.SetTrigger("Flip");
        }

        // Make the character move backwards
        if (!movingBackwards && moveInput.y > 0)
        {
            movingBackwards = true;
            flipAmin.SetTrigger("Flip");
        }
        else if (movingBackwards && moveInput.y == 0)
        {
            movingBackwards = false;
            flipAmin.SetTrigger("Flip");
        }

        // Make the character move forwards
        if (!movingForward && moveInput.y < 0)
        {
            movingForward = true;
            flipAmin.SetTrigger("Flip");
        }
        else if (movingForward && moveInput.y == 0)
        {
            movingForward = false;
            flipAmin.SetTrigger("Flip");
        }
        // Update movement animations for crouching
        anim.SetBool("isCrouching", isCrouching);
        anim.SetBool("movingBackwards", movingBackwards);
        anim.SetBool("movingForward", movingForward);


    }
}