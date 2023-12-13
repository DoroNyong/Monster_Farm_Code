using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    //public AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    [SerializeField] private SoundManager soundManager;

    [SerializeField] private Slider MasterSlider;

    private void Awake()
    {
        soundManager = SoundManager.instance;
    }

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height; // �ػ� string ex) 1280 * 720
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        soundManager.SetMasterSlier(MasterSlider);
    }

    public void SetResolution(int resolutionIndex) // �ػ� ����
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    //public void SetVolume(float volume)  // ����� ���� ����
    //{
    //    audioMixer.SetFloat("volume", volume);
    //}

    public void SetQuality(int qualityIndex)  // �׷��� ����
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)  // ��ü ȭ�� ���
    {
        Screen.fullScreen = isFullScreen;
    }
}
