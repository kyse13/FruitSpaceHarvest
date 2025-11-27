using UnityEngine;
using UnityEngine.UI;

public class SoundButtonController : MonoBehaviour
{
    public Button soundButton;
    public AudioSource[] audioSources;
    public Image buttonImage;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    private bool isSoundOn = true;
    private float soundVolume = 0.3f;
    private float soundOffVolume = 0f;
    private bool isOptionsMenuActive = false;

    private void Start()
    {
        soundButton.onClick.AddListener(ToggleSound);

        isSoundOn = PlayerPrefs.GetInt("SoundButtonSoundOn", 1) == 1;
        UpdateSoundState();
    }

    private void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        UpdateSoundState();

        PlayerPrefs.SetInt("SoundButtonSoundOn", isSoundOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void UpdateSoundState()
    {
        buttonImage.sprite = isSoundOn ? soundOnSprite : soundOffSprite;
        SetAudioSourcesVolume(isSoundOn ? soundVolume : soundOffVolume);
    }

    private void SetAudioSourcesVolume(float volume)
    {
        foreach (var audioSource in audioSources)
        {
            audioSource.volume = volume;
        }
    }

    public void SetOptionsMenuActive(bool isActive)
    {
        isOptionsMenuActive = isActive;
        if (!isActive && isSoundOn)
        {
            UnpauseAudioSources();
        }
        else
        {
            PauseAudioSources();
        }
    }

    public void SetRestarting(bool value)
    {
        isSoundOn = PlayerPrefs.GetInt("SoundButtonSoundOn", 1) == 1;
        UpdateSoundState();

        if (!isOptionsMenuActive)
        {
            if (isSoundOn)
            {
                UnpauseAudioSources();
            }
            else
            {
                PauseAudioSources();
            }
        }
    }

    private void PauseAudioSources()
    {
        foreach (var audioSource in audioSources)
        {
            audioSource.Pause();
        }
    }

    private void UnpauseAudioSources()
    {
        foreach (var audioSource in audioSources)
        {
            audioSource.UnPause();
        }
    }
}
