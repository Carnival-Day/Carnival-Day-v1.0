using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionControl : MonoBehaviour
{
    //Initialize variables
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;

    private float currentRefreshRate;
    private int currentResolutionIndex = 0;

    //Run function when game start
    void Start()
    {
        //Get current resolution
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        //Clear all values from dropdown menu
        resolutionDropdown.ClearOptions();

        //Get current refresh rate
        currentRefreshRate = Screen.currentResolution.refreshRate;

        //Iterate through the resolution array to check if refresh rates matched or not
        for (int i = 0; i < resolutions.Length; i++)
        {
            //If true, add that resolution to "filteredResolutions"
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        //Add filtered resolutions to dropdown menu values
        List<string> options = new List<string>();
        //Iterate through filteredResolutions and create a string for each
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            //Create a string with resolution and refresh rate, add to list "options"
            string resolutionOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRate + " Hz";
            options.Add(resolutionOption);
            //If a resolution match with the current screen's resolution, set equals to currentResolutionIndex
            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        //Add list of resolutions to dropdown menu values and refresh
        //Set dropdown value to current resolution
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    //Get the chosen resolution, set new resolution to screen
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
