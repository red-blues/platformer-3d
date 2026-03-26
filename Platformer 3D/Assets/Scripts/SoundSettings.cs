using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private Slider bgVolumeSlider;
    [SerializeField] private AudioMixer mixer;

    private const string master_volume = "MasterVolume";
    private const string sfx_volume = "SFXVolume";
    private const string bgr_volume = "BgVolume";

    private void Awake()
    {
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
        bgVolumeSlider.onValueChanged.AddListener(SetBgrVolume);
    }

    private void Start()
    {
        TryLoadVolume(master_volume, masterVolumeSlider, SetMasterVolume);
        TryLoadVolume(sfx_volume, sfxVolumeSlider, SetSFXVolume);
        TryLoadVolume(bgr_volume, bgVolumeSlider, SetBgrVolume);
    }

    private void SetMasterVolume(float value)
    {
        mixer.SetFloat(master_volume, GetMixerVolume(value));
        SaveVolume(master_volume, value);
    }

    private void SetSFXVolume(float value)
    {
        mixer.SetFloat(sfx_volume, GetMixerVolume(value));
        SaveVolume(sfx_volume, value);
    }

    private void SetBgrVolume(float value)
    {
        mixer.SetFloat(bgr_volume, GetMixerVolume(value));
        SaveVolume(bgr_volume, value);
    }

    private float GetMixerVolume(float value) =>
        Mathf.Log10(value) * 20;
    
    private void SaveVolume(string channel, float value) => 
        PlayerPrefs.SetFloat(channel, value);

    private void TryLoadVolume(string channel, Slider slider, Action<float> loadCallback)
    {
        if (PlayerPrefs.HasKey(channel))
        {
            float value = PlayerPrefs.GetFloat(channel);
            loadCallback.Invoke(value);
            slider.value = value;
        }
    }
}
