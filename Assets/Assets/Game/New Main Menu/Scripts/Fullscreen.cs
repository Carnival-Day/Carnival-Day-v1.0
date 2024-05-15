using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fullscreen : MonoBehaviour
{
    //Function to toggle fullscreen on or off
    public void Change()
    {
        Screen.fullScreen = !Screen.fullScreen;
        print("Toggled FullScreen");
    }
}
