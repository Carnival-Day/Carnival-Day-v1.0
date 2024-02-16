using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCS : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void OptionScreenTween()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), 50, 30f);
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), 130, 30f);
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), 80, 30f);
    }

    public void CancelTween()
    {
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), -470, 30f);
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), -390, 30f);
        LeanTween.moveY(gameObject.GetComponent<RectTransform>(), -440, 30f);
    }
}
