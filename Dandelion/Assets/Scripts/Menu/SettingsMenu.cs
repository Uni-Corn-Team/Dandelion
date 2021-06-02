using Assets.DandelionLib.Enums;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer am;
    Resolution[] rsl;
    List<string> resolutions;
    public Dropdown dropdown;
    public bool isFullScreen;
    public GameObject FSToggle;
    public Dropdown difficultyDropdown;
    List<string> difficultyTypes;

    public static DifficultyType currentDiffucultyType = DifficultyType.NormalGame;

    public void Awake()
    {
        FSToggle.GetComponent<Toggle>().isOn = Screen.fullScreen;
        isFullScreen = Screen.fullScreen;
        resolutions = new List<string>();
        rsl = Screen.resolutions;
        Resolution currentResolution = Screen.currentResolution;
        rsl[0] = currentResolution;
        for (int i = 0; i < resolutions.Count - 1; i++)
        {
            rsl[i + 1] = rsl[i];
        }
        foreach (var i in rsl)
        {
            resolutions.Add(i.width + "x" + i.height);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(resolutions);

        difficultyTypes = new List<string>();
        difficultyTypes.Add(nameof(DifficultyType.EasyGame));
        difficultyTypes.Add(nameof(DifficultyType.NormalGame));
        difficultyTypes.Add(nameof(DifficultyType.HardGame));
        difficultyTypes.Add(nameof(DifficultyType.ImpossibleGame));

        difficultyDropdown.ClearOptions();
        difficultyDropdown.AddOptions(difficultyTypes);

        DontDestroyOnLoad(this);
    }

    public void FullScreenToggle()
    {
        Screen.fullScreen = FSToggle.GetComponent<Toggle>().isOn;
        isFullScreen = FSToggle.GetComponent<Toggle>().isOn;
    }

    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("masterVolume", sliderValue);
    }

    public void Resolution(int r)
    {
        Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen);
    }

    public void Difficulty(int r)
    {
        currentDiffucultyType = (DifficultyType)r;
    }
}
