using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    // Assuming you have references to your sliders and toggles
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public Toggle muteMusicToggle;
    public Toggle muteSfxToggle;

    private void Start()
    {
        // Initialize the sliders to the current volumes
        musicVolumeSlider.value = SoundManager.Instance.musicSource.volume;
        sfxVolumeSlider.value = SoundManager.Instance.sfxSource.volume;

        // Initialize the toggles to the current mute states
        muteMusicToggle.isOn = SoundManager.Instance.musicSource.mute;
        muteSfxToggle.isOn = SoundManager.Instance.sfxSource.mute;

        // Add listeners for the sliders
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);

        // Add listeners for the toggles
        muteMusicToggle.onValueChanged.AddListener(MuteMusic);
        muteSfxToggle.onValueChanged.AddListener(MuteSFX);
    }

    private void SetMusicVolume(float volume)
    {
        SoundManager.Instance.musicSource.volume = volume;
    }

    private void SetSFXVolume(float volume)
    {
        SoundManager.Instance.sfxSource.volume = volume;
    }

    private void MuteMusic(bool mute)
    {
        SoundManager.Instance.musicSource.mute = mute;
    }

    private void MuteSFX(bool mute)
    {
        SoundManager.Instance.sfxSource.mute = mute;
    }
    public void ToggleOptionsMenu()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

}



