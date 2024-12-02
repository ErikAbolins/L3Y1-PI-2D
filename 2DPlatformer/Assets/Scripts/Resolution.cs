using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    public void SetWindowed()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
        Screen.SetResolution(1280, 720, false);
        Debug.Log("Set to Windowed");
    }
    public void SetFullScreen()
    {
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        Debug.Log("Set to Fullscreen");
    }
}
