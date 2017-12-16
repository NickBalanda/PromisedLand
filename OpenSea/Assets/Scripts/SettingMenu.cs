using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour {

    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    public Button fullScreenButton;
    bool isFullScreen;

    public Dropdown qualityDropdown;

    public Button vsyncButton;
    bool isvsyncOn;

    public Slider MusicSlider;
    public Slider SFXSlider;

    void Start() {
        SettupOptions();
    }

    void SettupOptions() {
        GetResolutions();

        isFullScreen = true;

        //Add Listeners
        resolutionDropdown.onValueChanged.AddListener(delegate { SetResolutions(resolutionDropdown); });
        fullScreenButton.onClick.AddListener(SetFullScreen);
        vsyncButton.onClick.AddListener(SetVsync);
        qualityDropdown.onValueChanged.AddListener(delegate {SetQuality(qualityDropdown);});
        SFXSlider.onValueChanged.AddListener(delegate { SetSFXVolume(); });
        MusicSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });
    }

    void GetResolutions() {
        //Get all resolutions available
        resolutions = Screen.resolutions;
        //Clear the dropdown options
        resolutionDropdown.ClearOptions();
        //Create a list of options
        List<string> options = new List<string>();
        //Create a int to store the current resolution 
        int currentResolutionIndex = 0;
        //Loop through the resolutions array and store it into the options list
        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + "X" + resolutions[i].height;
            options.Add(option);

            //Get the current screen resolution 
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }
        //Add the options list to the dropdown
        resolutionDropdown.AddOptions(options);
        //Set the current dropdown option to the current resolution index
        resolutionDropdown.value = currentResolutionIndex;
        //Refresh the dropdown shown value
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolutions(Dropdown resolution) {
        Resolution res = resolutions[resolution.value];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void SetFullScreen() {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
        if (isFullScreen) {
            fullScreenButton.GetComponentInChildren<Text>().text = "ON";
        } else {
            fullScreenButton.GetComponentInChildren<Text>().text = "OFF";
        }
    }

    public void SetQuality(Dropdown quality) {
        QualitySettings.SetQualityLevel(quality.value);
    }

    public void SetVsync() {
        isvsyncOn = !isvsyncOn;
        
        if (isvsyncOn) {
            QualitySettings.vSyncCount = 1;
            vsyncButton.GetComponentInChildren<Text>().text = "ON";
        } else {
            QualitySettings.vSyncCount = 0;
            vsyncButton.GetComponentInChildren<Text>().text = "OFF";
        }
    }

    public void SetSFXVolume() {

    }

    public void SetMusicVolume() {

    }

}
