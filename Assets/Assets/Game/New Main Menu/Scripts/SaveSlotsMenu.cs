using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlotsMenu : Menu
{
    
    [Header("Menu Navigation")]
    [SerializeField] private MainMenu mainMenu;

    [Header("Menu Buttons")]
    [SerializeField] private Button closeButton;

    private SaveSlot[] saveSlots;
    private bool isLoadingGame = false;

    private void Awake()
    {
        saveSlots = this.GetComponentsInChildren<SaveSlot>();
        this.DeactivateMenu();
    }

    public void OnSaveSlotClicked(SaveSlot saveSlot)
    {

        // disable all other buttons
        DisableMenuButtons();
        DataPersistenceManager.Instance.ChangeSelectedProfileId(saveSlot.GetProfileID());
        DataPersistenceManager.Instance.NewGame();

        if(!isLoadingGame )
        {
            DataPersistenceManager.Instance.NewGame();
        }
        DataPersistenceManager.Instance.SaveGame();
        SceneManager.LoadSceneAsync("Game");
    }
    public void OnBackClicked()
    {
        mainMenu.ActivateMenu();
        this.DeactivateMenu();
    }


    // load all existing profiles
    public void ActivateMenu(bool isLoadingGame)
    {
        // Awake();
        if (saveSlots == null)
        {
            saveSlots = this.GetComponentsInChildren<SaveSlot>();
            this.DeactivateMenu();
        }
        // Awake(); is called in the above 2 lines
        // set Load Menu to active
        this.gameObject.SetActive(true);

        this.isLoadingGame = isLoadingGame;

        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.Instance.GetAllProfilesGameData();
        
        // set the content for each save slot inside dictionary
        foreach( SaveSlot saveSlot in saveSlots )
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(saveSlot.GetProfileID(), out profileData);
            saveSlot.SetData(profileData);

            if(profileData == null && isLoadingGame)
            {
                saveSlot.SetInteractable(false);
            }
            else
            {
                saveSlot.SetInteractable(true);
            }
        }
    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }

    private void DisableMenuButtons()
    {
        foreach (SaveSlot saveSlot in saveSlots)
        {
            saveSlot.SetInteractable(false);
        }
        closeButton.interactable = false;
    }
    
}
