using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer am;
    Resolution[] rsl;
    List<string> resolutions;
    public Dropdown dropdown;
    bool isFullScreen = false;

    public void Awake()
    {
        resolutions = new List<string>();
        rsl = Screen.resolutions;
        foreach (var i in rsl)
        {
            resolutions.Add(i.width + "x" + i.height);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutions);
        
    }

    public void FullScreenToggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
        isFullScreen = !isFullScreen;
    }

    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("masterVolume", sliderValue);
    }

    public void Resolution(int r)
    {
        Debug.Log("rsl[r].width " + rsl[r].width  + " rsl[r].height " +  rsl[r].height  +" " + isFullScreen);
        Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen);
    }
}
