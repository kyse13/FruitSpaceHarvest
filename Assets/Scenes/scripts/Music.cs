using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
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
    private bool isRestarting = false;
    private bool shouldResumeMusic = false; 
    private bool isFirstPlay = true;

    private void Start()
    {
        soundButton.onClick.AddListener(ToggleSound);

        isSoundOn = PlayerPrefs.GetInt("MusicSoundOn", 1) == 1;
        UpdateSoundState();

        if (!isSoundOn && !isRestarting)
        {
            PauseAudioSources();
        }

        
        if (PlayerPrefs.HasKey("MusicFirstPlay"))
        {
            isFirstPlay = false;
        }
        else
        {
            PlayerPrefs.SetInt("MusicFirstPlay", 1);
            PlayerPrefs.Save();
            isFirstPlay = true;
        }
    }

    private void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        UpdateSoundState();

        PlayerPrefs.SetInt("MusicSoundOn", isSoundOn ? 1 : 0);
        PlayerPrefs.Save();

        if (!isSoundOn)
        {
            PauseAudioSources();
        }
        else if (!isOptionsMenuActive && !isRestarting && !isFirstPlay)
        {
            shouldResumeMusic = true; 
        }
    }

    private void SetAudioSourcesVolume(float volume)
    {
        foreach (var audioSource in audioSources)
        {
            audioSource.volume = volume;
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

    public void SetOptionsMenuActive(bool isActive)
    {
        isOptionsMenuActive = isActive;
        if (!isActive && isSoundOn && shouldResumeMusic && !isRestarting)
        {
            UnpauseAudioSources();
        }
        shouldResumeMusic = false; 
    }

    public void SetRestarting(bool value)
    {
        isRestarting = value;
        if (value)
        {
            isSoundOn = false;
            UpdateSoundState();
            StopAudioSources();
        }
        else
        {
            isSoundOn = PlayerPrefs.GetInt("MusicSoundOn", 1) == 1;
            UpdateSoundState();

            if (isSoundOn && !isOptionsMenuActive && !isFirstPlay)
            {
                UnpauseAudioSources();
            }
        }
    }

    private void UpdateSoundState()
    {
        buttonImage.sprite = isSoundOn ? soundOnSprite : soundOffSprite;
        SetAudioSourcesVolume(isSoundOn ? soundVolume : soundOffVolume);
    }

    private void StopAudioSources()
    {
        foreach (var audioSource in audioSources)
        {
            audioSource.Stop();
        }
    }
}