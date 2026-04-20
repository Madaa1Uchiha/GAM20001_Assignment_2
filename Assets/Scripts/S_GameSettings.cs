using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class GameSettings : MonoBehaviour
{   
    public TMP_Dropdown ResDropDown;    
    public Toggle FullScreenToggle;    
    private int SelectedResolution;
    private bool IsFullscreen;
    Resolution[] AllResolutions;
    List<Resolution> SelectedResolutionList = new List<Resolution>();

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

    void Start()
    {
        Debug.Log("Resolution count: " + Screen.resolutions.Length);
        IsFullscreen = Screen.fullScreen;
        FullScreenToggle.isOn = IsFullscreen;
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, IsFullscreen);
        
        AllResolutions = Screen.resolutions;
        List<string> resolutionStringList = new List<string>();
        int currentIndex = 0;

        foreach(Resolution res in AllResolutions)
        {
            string newRes = res.width.ToString() + " x " + res.height.ToString();
            if(!resolutionStringList.Contains(newRes))
            {
                resolutionStringList.Add(newRes);
                SelectedResolutionList.Add(res);

                if(res.width == Screen.currentResolution.width && 
                   res.height == Screen.currentResolution.height)
                {
                    currentIndex = SelectedResolutionList.Count - 1;
                }
            }
        }
        if(AllResolutions.Length == 0)
        {
            Screen.SetResolution(1920, 1080, IsFullscreen);
            ResDropDown.AddOptions(new List<string> { "1920 x 1080", "1280 x 720", "800 x 600" });
            return;
        }

        ResDropDown.ClearOptions();
        ResDropDown.AddOptions(resolutionStringList);
        ResDropDown.value = currentIndex;
        SelectedResolution = currentIndex;
    }
}