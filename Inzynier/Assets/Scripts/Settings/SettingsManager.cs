using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] TMP_Text volumeVal;

    public Slider slider;
    private float sliderValue;

    public AudioMixer audioMixer;

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
        volumeVal.text = PlayerPrefs.GetFloat("volume").ToString();
        PlayerPrefs.Save();
    } 

    void Start()
    {
        setSlider();
        slider.value = PlayerPrefs.GetFloat("volume", sliderValue);
    }

    private void setSlider()
    {
        sliderValue = PlayerPrefs.GetFloat("volume");
        volumeVal.text = sliderValue.ToString();
        PlayerPrefs.SetFloat("volume",sliderValue);
        PlayerPrefs.Save();
    }

}
