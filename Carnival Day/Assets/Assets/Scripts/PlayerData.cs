using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// The player controller class can insert playerdata objects to mongodb
using MongoDB.Driver;
using MongoDB.Bson;

// The class is a data holder
// Removing the monobehavior for unity
// Create a dataholder for mongodb
public class PlayerData
{
    public ObjectId _id { set; get; }

    public string aName { set; get; }

    public int aValue { set; get; }
}
