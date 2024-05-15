using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrizeMenu : MonoBehaviour, IDataPersistence
{
    public GameObject prizeMenu;
    private bool prize1 = false;
    private bool prize2 = false;
    private bool prize3 = false;
    private bool prize4 = false;
    private GameData gameData;
    private int currency = 0;



    public void LoadData(GameData data)
    {
        this.prize1 = data.prize1;
        this.prize2 = data.prize2;
        this.prize3 = data.prize3;
        this.prize4 = data.prize4;
        this.currency = data.currency;
    }

    public void SaveData(ref GameData data)
    {
        data.prize1 = this.prize1;
        data.prize2 = this.prize2;
        data.prize3 = this.prize3;
        data.prize4 = this.prize4;
        data.currency = this.currency;
    }



    public bool CheckPrerequisitesAndUnlock(string prize)
    {
        if (currency >= 100)
        {
            return AttemptToUnlockPrize(prize);
        }
        else
        {
            Debug.Log("PrizeMenu.cs: Not enough currency to unlock " + prize);
            return false;
        }
    }


    private bool AttemptToUnlockPrize(string prize)
    {
        bool canUnlock = IsPrizeUnlockable(prize);

        return canUnlock;
    }

    private bool IsPrizeUnlockable(string prize)
    {
        switch (prize)
        {
            case "Prize1":
                if (prize1)
                {
                    Debug.Log("PrizeMenu.cs: Prize1 already unlocked");
                    return false;
                }
                else
                {
                    if (currency >= 100)
                    {
                        Debug.Log("PrizeMenu.cs: Prize1 unlocked successfully");
                        currency -= 100;
                        // inventoryManager.AddItem(itemsToSpawn[0]);
                        prize1 = true;
                    }
                    else
                    {
                        Debug.Log("PrizeMenu.cs: Not enough currency to unlock " + prize);
                        return false;
                    }
                }
                return true;
            case "Prize2":
                if (prize2)
                {
                    Debug.Log("PrizeMenu.cs: Prize2 already unlocked");
                    return false;
                }
                else
                {
                    if (currency >= 100)
                    {
                        Debug.Log("PrizeMenu.cs: Prize2 unlocked successfully");
                        currency -= 100;

                        // inventoryManager.AddItem(itemsToSpawn[1]);
                        prize2 = true;
                    }
                    else
                    {
                        Debug.Log("PrizeMenu.cs: Not enough currency to unlock " + prize);
                        return false;
                    }
                }
                return true;
            case "Prize3":
                if (prize3)
                {
                    Debug.Log("PrizeMenu.cs: Prize3 already unlocked");
                    return false;
                }
                else
                {
                    if (currency >= 100)
                    {
                        Debug.Log("PrizeMenu.cs: Prize3 unlocked successfully");
                        currency -= 100;

                        // inventoryManager.AddItem(itemsToSpawn[2]);
                        prize3 = true;
                    }
                    else
                    {
                        Debug.Log("PrizeMenu.cs: Not enough currency to unlock " + prize);
                        return false;
                    }
                }
                return true;
            case "Prize4":
                if (prize4)
                {
                    Debug.Log("PrizeMenu.cs: Prize4 already unlocked");
                    return false;
                }
                else
                {

                    if (currency >= 100)
                    {
                        Debug.Log("PrizeMenu.cs: Prize4 unlocked successfully");
                        currency -= 100;

                        // inventoryManager.AddItem(itemsToSpawn[3]);
                        prize4 = true;
                    }
                    else
                    {
                        Debug.Log("PrizeMenu.cs: Not enough currency to unlock " + prize);
                        return false;
                    }
                }
                return true;
            default:
                Debug.Log("PrizeMenu.cs: Invalid prize name");
                return false;
        }
    }


    public void LoadPrize1()
    {
        Debug.Log("PrizeMenu.cs: Attempting to unlock Prize1");
        if (CheckPrerequisitesAndUnlock("Prize1"))
        {
            Debug.Log("PrizeMenu.cs: Prize1 unlocked successfullycurrency is " + currency);
            DataPersistenceManager.Instance.SaveGame();
            Debug.Log("PrizeMenu.cs: currency is " + currency);


        }
    }

    public void LoadPrize2()
    {
        Debug.Log("PrizeMenu.cs: Attempting to unlock Prize2");
        if (CheckPrerequisitesAndUnlock("Prize2"))
        {
            Debug.Log("PrizeMenu.cs: Prize2 unlocked successfully");
            DataPersistenceManager.Instance.SaveGame();
        }
    }

    public void LoadPrize3()
    {
        Debug.Log("PrizeMenu.cs: Attempting to unlock Prize3");
        if (CheckPrerequisitesAndUnlock("Prize3"))
        {
            Debug.Log("PrizeMenu.cs: Prize3 unlocked successfully");

            DataPersistenceManager.Instance.SaveGame();
        }
    }

    public void LoadPrize4()
    {
        Debug.Log("PrizeMenu.cs: Attempting to unlock Prize4");
        if (CheckPrerequisitesAndUnlock("Prize4"))
        {
            Debug.Log("PrizeMenu.cs:PrizeMenu.cs: Prize4 unlocked successfully");
            DataPersistenceManager.Instance.SaveGame();
        }
    }

    public void LoadESCScene()
    {
        SceneManager.LoadScene("Game");
    }
}
