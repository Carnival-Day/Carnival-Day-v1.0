using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

// Done by: Vanessa Ramirez
public class QuestBookButtonBehavior : MonoBehaviour
{
    [SerializeField] private GameObject questPage;
    [SerializeField] private Text questTextBox;
    [SerializeField] private string[] noQuestsText;
    private bool openBook;

    private void Update()
    {
        // Check if the "J" key is pressed to toggle the quest book
        if (Input.GetKeyDown(KeyCode.J))
        {
            // Toggle the quest book
            ToggleQuestBook();
        }
    }

    private void ToggleQuestBook()
    {
        // Toggle the state of the quest book
        openBook = !openBook;
        // Update the display based on the state of the quest book
        CreatePage();
        // Update the displayed quests
        WriteQuests();
    }

    public void OpenQuestBook()
    {
        // Call ToggleQuestBook() to open the quest book
        ToggleQuestBook();
    }

    public void CreatePage()
    {
        // Check if questPage is assigned
        if (questPage != null)
        {
            // Activate or deactivate the quest page based on the openBook flag
            questPage.SetActive(openBook);
        }
    }

    private void WriteQuests()
    {
        // Check if questTextBox is assigned
        if (questTextBox != null)
        {
            // Check if MainManager and questNames are assigned
            if (MainManager.mainManager != null && MainManager.mainManager.questNames != null)
            {
                // Check if there are no quests
                if (MainManager.mainManager.questNames.Count == 0)
                {
                    // Display a random noQuestsText or a default message
                    if (noQuestsText != null && noQuestsText.Length > 0)
                    {
                        int randomNumber = Random.Range(0, noQuestsText.Length);
                        questTextBox.text = noQuestsText[randomNumber];
                    }
                    else
                    {
                        questTextBox.text = "No quests available.";
                    }
                }
                else
                {
                    // Construct the list of quests
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (string quest in MainManager.mainManager.questNames)
                    {
                        stringBuilder.AppendLine(quest);
                    }
                    // Display the quests in questTextBox
                    questTextBox.text = stringBuilder.ToString();
                }
                // Adjust the size of questTextBox to fit the quests
                questTextBox.rectTransform.sizeDelta = new Vector2(questTextBox.rectTransform.sizeDelta.x, questTextBox.preferredHeight);
            }
            else
            {
                // Warn if MainManager or questNames is not assigned
                Debug.LogWarning("MainManager or questNames is null.");
            }
        }
        else
        {
            // Warn if questTextBox is not assigned
            Debug.LogWarning("questTextBox is null.");
        }
    }
}