using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using System.Collections.Generic;
public class GameSettings : MonoBehaviour
{   
    public TMP_Dropdown ResDropDown;    
    public Toggle FullScreenToggle;    
    private int SelectedResolution;
    private bool IsFullscreen;

    public void ChangeScreenSize()
    {
       IsFullscreen = FullScreenToggle.isOn;
       Screen.SetResolution(SelectedResolutionList[SelectedResolution].width, SelectedResolutionList[SelectedResolution].height, IsFullscreen);
    }

    public void ChangeResolution()
    {
        SelectedResolution = ResDropDown.value;
        Screen.SetResolution(SelectedResolutionList[SelectedResolution].width, SelectedResolutionList[SelectedResolution].height, IsFullscreen);
    }

    Resolution[] AllResolutions;
    List<Resolution> SelectedResolutionList = new List<Resolution>();

    void Start()
    {
        IsFullscreen = true;
        AllResolutions = Screen.resolutions;

        List<string> resolutionStringList = new List<string>();
        string newRes;
        foreach(Resolution res in AllResolutions)
        {
            newRes = res.width.ToString() +" x " + res.height.ToString();
            if(!resolutionStringList.Contains(newRes))
            {
                resolutionStringList.Add(newRes);
                SelectedResolutionList.Add(res);
            }
        }

        ResDropDown.AddOptions(resolutionStringList);
    }
    
}
