using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
// This class is worked on by Vanessa and Derick. More imporvements will be made by the entire team.
public class PlayerData
{
    // Below we are initializing the variables that will be stored in the database
    public ObjectId _id { set; get; }

    public string aName { set; get; }

    public int currency { set; get; }

    public bool[] miniGame1 { set; get; }
    public int miniGame1Score { set; get; }
    public int miniGame2Score { set; get; }
    public int miniGame3Score { set; get; }
    public bool[] miniGame2 { set; get; }
    public bool[] miniGame3 { set; get; }
    public bool Prize1 { set; get; }
    public bool Prize2 { set; get; }

    public bool Prize3 { set; get; }
    public bool Prize4 { set; get; }
    public int aValue { set; get; }


    public float[] aLocationArray { set; get; }
    // Constructor for the player data
    // Sets in the initial values for the player data
    public PlayerData()
    {
        // Initialize mini-games to false
        miniGame1 = new bool[] { false };
        miniGame2 = new bool[] { false };
        miniGame3 = new bool[] { false };
        miniGame1Score = 0;
        miniGame2Score = 0;
        miniGame3Score = 0;
        Prize1= false;
        Prize2 = false;

        // Set currency to 3000
        currency = 3000;
        aLocationArray = new float[2];
    }
}
