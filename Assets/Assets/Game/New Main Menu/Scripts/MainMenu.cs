using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class MainMenu : Menu
{

    [Header("Menu Navigation")]
    [SerializeField] private SaveSlotsMenu saveSlotsMenu;

    [Header("Menu Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button loadGameButton;

    private void Start()
    {
        saveSlotsMenu.DeactivateMenu();
        if (!DataPersistenceManager.Instance.HasGameData())
        {
            loadGameButton.interactable = false;
        }
        

    }

    public void OnNewGameClicked()
    {
        saveSlotsMenu.ActivateMenu(false);
        //this.DeactivateMenu();
        //DataPersistenceManager.Instance.NewGame();
        //SceneManager.LoadSceneAsync("Game");
    }

    public void OnLoadGameClicked()
    {
        saveSlotsMenu.ActivateMenu(true);
        //this.DeactivateMenu();
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        loadGameButton.interactable = false;
    }

    public void ActivateMenu()
    {
        this.gameObject.SetActive(true);
    }

    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }
}
