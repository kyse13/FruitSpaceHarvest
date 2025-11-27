using UnityEngine;
using UnityEngine.UI;

public class ReturnButtonController : MonoBehaviour
{
    public Button returnButton;
    public GameObject optionsPrefab;
    public AudioSource backgroundSound;
    public Vector3 targetPosition; 

    private bool isMenuVisible = true; 

    private void Start()
    {
        returnButton.onClick.AddListener(ToggleMenu);
    }

    private void ToggleMenu()
    {
        isMenuVisible = !isMenuVisible;

        if (optionsPrefab != null)
        {
            optionsPrefab.transform.position = isMenuVisible ? targetPosition : transform.position;
        }

        if (backgroundSound != null)
        {
            if (isMenuVisible)
            {
                backgroundSound.Pause();
            }
            else
            {
                backgroundSound.Play();
            }
        }

        Time.timeScale = isMenuVisible ? 0f : 1f;
    }
}
