using UnityEngine;
using UnityEngine.UI;

public class return_ : MonoBehaviour
{
    public Button returnButton;
    public GameObject optionsPrefab;
    public AudioSource backgroundSound;
    public Vector3 targetPosition; 

    private void Start()
    {
        returnButton.onClick.AddListener(ReturnToGame);
    }

    private void ReturnToGame()
    {
        if (optionsPrefab != null)
        {
            optionsPrefab.transform.position = targetPosition;
        }

        if (backgroundSound != null)
        {
            backgroundSound.Play();
        }

        Time.timeScale = 1f;
    }
}
