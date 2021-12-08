using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Audio;


public class SettingsManager : MonoBehaviour
{
    [SerializeField] TMP_Text volumeVal;

    public Slider slider;
    private float sliderValue;

    public AudioMixer audioMixer;

    Resolution[] resolutions;
    public TMPro.TMP_Dropdown resDropdown;

    public TMPro.TMP_Dropdown qualDropdown;

    public Toggle fullscreenToggle;

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume)*20);

        PlayerPrefs.SetFloat("volume", volume);
        volumeVal.text = Math.Round(PlayerPrefs.GetFloat("volume")*100,0).ToString();
        PlayerPrefs.Save();
    } 

    void Start()
    {
        if(PlayerPrefs.GetInt("fullscreen") == 1) fullscreenToggle.isOn = true;
        else fullscreenToggle.isOn = false;

        startResolutions();
        setSlider();

        resDropdown.value = PlayerPrefs.GetInt("resolution");
        slider.value = PlayerPrefs.GetFloat("volume", sliderValue);
        qualDropdown.value = PlayerPrefs.GetInt("quality");
    }

    private void startResolutions()
    {
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResIndex = 0;
        for(int i=0 ;i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        }

        resDropdown.AddOptions(options);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();
    }

    public void setResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("resolution",resIndex);
        PlayerPrefs.Save();
    }

    private void setSlider()
    {
        sliderValue = PlayerPrefs.GetFloat("volume");
        volumeVal.text = Math.Round((sliderValue*100),0).ToString();
        PlayerPrefs.SetFloat("volume",sliderValue);
        PlayerPrefs.Save();
    }

    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("quality", qualityIndex);
        PlayerPrefs.Save();
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("fullscreen",(isFullscreen == true) ? 1 : 0);
        PlayerPrefs.Save();
    }

}
