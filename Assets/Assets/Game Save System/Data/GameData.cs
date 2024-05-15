using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using UnityEngine;
using Debug = UnityEngine.Debug;

[System.Serializable]

public class GameData
{
    public int deathCount = 0;
    public string playerName;
    public Vector3 playerPosition;

    public bool prize1 = false;
    public bool prize2 = false;
    public bool prize3 = false;
    public bool prize4 = false;

    public int currency = 500;

    public bool whackamole = false;
    public bool balloonpop = false;
    public List<Items> Inventory;

    public GameData()
    {
        this.deathCount = 0;
        this.playerName = "Phyllie";
        this.playerPosition = new Vector3(-31.27f, 4.3f, 84f);
        this.Inventory = new List<Items>();
        this.prize1=false;
        this.prize2=false;
        this.prize3=false;
        this.prize4=false;
        this.currency=500;
        this.whackamole=false;
        this.balloonpop=false;
        {
            new Items()
                {
                    Name = "Map",
                    IsConsumable = false,
                    Quantity = 1
                };
        };
    }

}
