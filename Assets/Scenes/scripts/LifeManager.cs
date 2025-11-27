using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeManager : MonoBehaviour
{
    public GameObject[] hearts;
    public GameObject gameOverObject;
    public AudioSource backgroundAudio;
    private int currentLives;

    private int initialLives;

    private void Start()
    {
        currentLives = hearts.Length;
        initialLives = currentLives;

        hearts = new GameObject[currentLives];
        for (int i = 0; i < currentLives; i++)
        {
            hearts[i] = GameObject.Find("Heart" + (i + 1));
        }
    }

    public void DecreaseLives()
    {
        if (currentLives > 0)
        {
            currentLives--;
            hearts[currentLives].SetActive(false);

            if (currentLives == 0)
            {
                GameOver();
            }
        }
    }

    public void ResetLives()
    {
        currentLives = initialLives;

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(true);
        }

        gameOverObject.SetActive(false);
        backgroundAudio.Play();
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        gameOverObject.SetActive(true);
        backgroundAudio.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fruit"))
        {
            DecreaseLives();
            Destroy(collision.gameObject);
        }
    }
}
