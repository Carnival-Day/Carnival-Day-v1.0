using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour, IDataPersistence
{
    //Assign inventory manager and item to spawn
    public InventoryManager inventoryManager;
    public Item[] itemsToSpawn;

    //Initialize variables for database
    private bool prize1 = false;
    private bool prize2 = false;
    private bool prize3 = false;
    private bool prize4 = false;
    private int currency;

    //Load data from database
    private GameData gameData;
    public void LoadData(GameData data)
    {
        this.prize1 = data.prize1;
        this.prize2 = data.prize2;
        this.prize3 = data.prize3;
        this.prize4 = data.prize4;
        this.currency = data.currency;

    }

    //Save data to database
    public void SaveData(ref GameData data)
    {
        data.prize1 = this.prize1;
        data.prize2 = this.prize2;
        data.prize3 = this.prize3;
        data.prize4 = this.prize4;
        data.currency = this.currency;
    }

    //Spawn item using id
    public void TestSpawnItem(int id) {

        if (id==0 && prize1==true){
            Debug.Log("You already purchased this prize");
        }
        else if (id == 1 && prize2 == true){
            Debug.Log("You already purchased this prize");
        }
        else if (id == 2 && prize3 == true){
            Debug.Log("You already purchased this prize");
        }
        else if (id == 3 && prize4 == true){
            Debug.Log("You already purchased this prize");
        }


        if (id ==0 && prize1==false){
            id = 0;
        }
        else if (id == 1 && prize2 == false){
            id = 1;
        }
        else if (id == 2 && prize3 == false){
            id = 2;
        }
        else if (id == 3 && prize4 == false){
            id = 3;
        }
        else{
            Debug.Log("Prize already claimed");
            return;
        }
        bool result = inventoryManager.AddItem(itemsToSpawn[id]);
        if (result == true) {
            Debug.Log("Item added");
        } else {
            Debug.Log("INVENTORY IS FULL");
        }
    }
    
}
