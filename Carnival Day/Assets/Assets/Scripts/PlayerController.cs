using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;
using MongoDB.Driver;

//start() load player data, gives a tag, starts a code routine to download data from mongodb
public class PlayerController : MonoBehaviour
{
    // References
    public Rigidbody theRB;

    // Reference to player data
    private PlayerData _playerData;

    // Client establishes link from unity to the mongodb server
    private MongoClient client;
    // Database allows us to pick which database within the server to pull from
    private IMongoDatabase database;
    // Collection allows us to make reference to the collection within the database given a type (playerdata)
    private IMongoCollection<PlayerData> collection;

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

    // Start is called before the first frame update
    void Start()
    {
        // Create a link to mongodb server
        client = new MongoClient("mongodb+srv://andrewnguyen22:5900@carnivalday.zvgjz0w.mongodb.net/");
        database = client.GetDatabase("TestDB");
        collection = database.GetCollection<PlayerData>("testCollection");

        // Attempts to pull the playerdata from mongodb server using aName as the key
        PlayerData playerFromMongo = collection.Find(data => data.aName=="Honk").SingleOrDefault();
        // If nothing was pulled from the server
        if (playerFromMongo == null) {
            // Create playerdata when the game is running to define some variable
            _playerData = new PlayerData();
            _playerData.aName = "Laika";
            _playerData.aValue = 0;
        } else {
            // PlayerData as PlayerfromMongo
            _playerData = playerFromMongo;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Walking input
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        // Walking speed
        theRB.velocity = new Vector3(moveInput.x * moveSpeed, theRB.velocity.y, moveInput.y * moveSpeed);
        anim.SetFloat("moveSpeed", theRB.velocity.magnitude);

        // Make the character flip from right to left
        if(!theSR.flipX && moveInput.x < 0)
        {
            theSR.flipX = true;
            flipAmin.SetTrigger("Flip");
        } else if(theSR.flipX && moveInput.x > 0)
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
        anim.SetBool("movingBackwards", movingBackwards);
        anim.SetBool("movingForward", movingForward);

        // When the user hits z we decrement the value, if they hit x to increment
        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            _playerData.aValue--;
            Debug.Log(_playerData.aValue);
        }
        else if (Input.GetKeyDown(KeyCode.X)) 
        {
            _playerData.aValue++;
            Debug.Log(_playerData.aValue);
        }
    }

    // Whenever the game stops running it will execute whatever is in there last
    void OnApplicationQuit() 
    {
        // Attempts to pull the playerdata from mongodb server using aName as the key
        PlayerData playerFromMongo = collection.Find(data => data.aName=="Honk").SingleOrDefault();
        // If nothing was pulled from the server
        if (playerFromMongo == null) {
            // Inserting the playerdata object to mongodb
            collection.InsertOne( _playerData );
        } else {
            // Replace the data existing within mongodb with the updated player data from the play session
            collection.FindOneAndReplace(data => data.aName=="Honk", _playerData);
        }
    }
}

