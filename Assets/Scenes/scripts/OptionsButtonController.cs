using UnityEngine;
using UnityEngine.UI;

public class OptionsButtonController : MonoBehaviour
{
    public Button optionsButton;
    public Button returnButton;
    public GameObject optionsMenu;
    public GameObject gameOverMenu; 
    public Vector3 targetPosition;
    public Vector3 defaultPosition;
    public AudioSource backgroundSound;

    private bool isMenuVisible = false; 

    private void Start()
    {
        optionsButton.onClick.AddListener(ToggleOptions);
        returnButton.onClick.AddListener(ReturnToDefault);
        defaultPosition = optionsMenu.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuVisible)
            {
                ReturnToDefault();
            }
            else
            {
                ToggleOptions();
            }
        }
    }

    private void ToggleOptions()
    {
        if (gameOverMenu.activeSelf) 
        {
            return; 
        }

        isMenuVisible = !isMenuVisible;

        if (isMenuVisible)
        {
            MoveMenuToTargetPosition();
            PauseGame();
            optionsButton.interactable = false; 
        }
        else
        {
            MoveMenuToDefaultPosition();
            ResumeGame();
            optionsButton.interactable = !optionsMenu.activeSelf; 
        }
    }

    private void MoveMenuToTargetPosition()
    {
        optionsMenu.transform.position = targetPosition;
        if (backgroundSound != null && backgroundSound.isPlaying)
        {
            backgroundSound.Pause();
        }
    }

    private void MoveMenuToDefaultPosition()
    {
        optionsMenu.transform.position = defaultPosition;
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        if (backgroundSound != null && !backgroundSound.isPlaying)
        {
            backgroundSound.UnPause();
        }
    }

    private void ReturnToDefault()
    {
        isMenuVisible = false;
        MoveMenuToDefaultPosition();
        ResumeGame();
        optionsButton.interactable = true; 
    }
}
