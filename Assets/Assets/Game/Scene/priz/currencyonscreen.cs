using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using Text = UnityEngine.UI.Text;

public class currencyonscreen : MonoBehaviour, IDataPersistence
{
    private GameData gameData;

    public GameObject currencyonscreenobject;

    private int currency = 0;
    public void LoadData(GameData data)
    {
        this.currency = data.currency;
        Debug.Log("Currency loaded: " + currency);
        UpdateUI();
    }

    public void SaveData(ref GameData data)
    {
        data.currency = this.currency;
    }

    public static currencyonscreen instance;

    public Text currencytext;


    // unity provided function to call UIManager instance and allows us to request UpdateUI()
    void Awake()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        Debug.Log("uPDATEui Currency: " + currency);
        currencytext.text = "$: " + currency;
    }

}
