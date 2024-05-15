using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Text = UnityEngine.UI.Text;

public class InventoryManager : MonoBehaviour, IDataPersistence
{
    //Make an array to store inventory slots
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    //Initialize variables for database
    private bool prize1 = false;
    private bool prize2 = false;
    private bool prize3 = false;
    private bool prize4 = false;
    private int currency = 0;
    public Text thecurrencytext;
    private GameData gameData;
    //Load from database
    public void LoadData(GameData data)
    {
        this.prize1 = data.prize1;
        this.prize2 = data.prize2;
        this.prize3 = data.prize3;
        this.prize4 = data.prize4;
        this.currency = data.currency;

    }

    //Save to database
    public void SaveData(ref GameData data)
    {
        data.prize1 = this.prize1;
        data.prize2 = this.prize2;
        data.prize3 = this.prize3;
        data.prize4 = this.prize4;
        data.currency = this.currency;
    }

    //Iterate through inventory to find empty slot
    //Call SpawnItem if slot is open
    public bool AddItem(Item item) {
        for (int i = 0; i < inventorySlots.Length; i++) {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null) {
                SpawnItem(item, slot);
                Debug.Log("InventoryManager.cs: Currency is " + currency);
                // UpdateCurrencyDisplay(); // THIS IS FOR CURRENCY SHOWN WITHIN INVENTORY, BUT WE ARE NOW DOING IT ON GAME SCREEN
                return true;
            }
        }
        return false;
    }
    
    //Spawn item into inventory
    //Create a new GameObject in the scene using prefab
    void SpawnItem(Item item, InventorySlot slot) {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        //Get InventoryItem script for new GameObject
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item);

    }
    void UpdateCurrencyDisplay()
    {
        Debug.Log("InventoryManager.cs: Updating currency display" + currency);
        if (thecurrencytext != null)
        {
            thecurrencytext.text = "$: " + currency.ToString();
        }else{
            Debug.LogWarning("InventoryManager.cs: No currency text found");
        }
    }
}
