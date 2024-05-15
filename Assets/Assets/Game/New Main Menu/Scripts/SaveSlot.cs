using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    
    [Header("Profile")]
    [SerializeField] private string profileId = "";

    [Header("Content")]
    [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;
    [SerializeField] private TextMeshProUGUI timestamp;

    private Button saveSlotButton;

    private void Awake()
    {
        saveSlotButton = this.GetComponent<Button>();
    }
  
    public void SetData(GameData data)
    {
        if (data == null)
        {
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
        }
        else
        {
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);

            if( timestamp != null)
            {
                timestamp.text = profileId + "\n" + System.DateTime.Now.ToString("MMM d, yyyy  HH:mm");
            }
        }
    }

    public string GetProfileID()
    {
        return this.profileId;
    }

    public void SetInteractable(bool interactable)
    {
        if (saveSlotButton == null)
        {
            saveSlotButton = this.GetComponent<Button>();
        }
        saveSlotButton.interactable = interactable;
    }
    
}
