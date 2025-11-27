using UnityEngine;
using UnityEngine.SceneManagement;

public class AgainButton : MonoBehaviour
{
    private bool isSoundOn = true;

    private void Start()
    {
       
        isSoundOn = PlayerPrefs.GetInt("ButtonSoundOn", 1) == 1;
        UpdateSoundState();
    }

    public void StartGame()
    {
        Time.timeScale = 1f;

        StopAudioSources(); 

        var musicScript = FindObjectOfType<Music>();
        if (musicScript != null)
        {
            musicScript.SetRestarting(true);
        }

        var soundButtonScript = FindObjectOfType<SoundButtonController>();
        if (soundButtonScript != null)
        {
            soundButtonScript.SetRestarting(true);
        }

        SceneManager.LoadScene("MainScenes");
    }

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        UpdateSoundState();

        PlayerPrefs.SetInt("ButtonSoundOn", isSoundOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void UpdateSoundState()
    {
        
        var musicScript = FindObjectOfType<Music>();
        if (musicScript != null)
        {
            musicScript.SetOptionsMenuActive(false);
        }

        var soundButtonScript = FindObjectOfType<SoundButtonController>();
        if (soundButtonScript != null)
        {
            soundButtonScript.SetOptionsMenuActive(false);
        }
    }

    private void StopAudioSources()
    {
        var musicScript = FindObjectOfType<Music>();
        if (musicScript != null)
        {
            musicScript.SetOptionsMenuActive(false);
        }

        var soundButtonScript = FindObjectOfType<SoundButtonController>();
        if (soundButtonScript != null)
        {
            soundButtonScript.SetOptionsMenuActive(false);
        }
    }
}