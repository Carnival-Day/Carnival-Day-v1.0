using System;
using MongoDB.Driver;
using UnityEngine;
using MongoDB.Bson;

public class MongoDBManager : MonoBehaviour
{
    private static MongoDBManager instance;
    private MongoClient client;
    private IMongoDatabase database;

    public static MongoDBManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MongoDBManager>();
            }
            return instance;
        }
    }

    public void UpdateGameData(string profileId, GameData gameData)
    {
        var collection = database.GetCollection<BsonDocument>("GameData");
        var filter = Builders<BsonDocument>.Filter.Eq("ProfileId", profileId);
        var update = Builders<BsonDocument>.Update.Set("Data", gameData.ToBsonDocument());
        var options = new UpdateOptions { IsUpsert = true };
        collection.UpdateOneAsync(filter, update, options);
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        ConnectToDatabase();
    }

    private void ConnectToDatabase()
    {
        client = new MongoClient("mongodb+srv://andrewnguyen22:5900@carnivalday.zvgjz0w.mongodb.net/");
        database = client.GetDatabase("TestDB");
    }



}
