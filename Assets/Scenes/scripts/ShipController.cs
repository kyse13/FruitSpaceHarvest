using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShipController : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI ScoreText2;
    public TextMeshProUGUI BestScoreText;
    public TextMeshProUGUI BestScoreText2;
    public LifeManager lifeManager;

    public AudioSource scoreSound;
    public AudioSource collisionSound;

    private int bestScore = 0;

    private void Start()
    {
        
        bestScore = PlayerPrefs.GetInt("Рекорд", 0);

   
        BestScoreText.text = "Рекорд  " + bestScore.ToString();
        BestScoreText2.text = "Рекорд  " + bestScore.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            Destroy(collision.gameObject);
            score += 10;
            UpdateScoreText();
            scoreSound.Play();
        }
        else if (collision.gameObject.CompareTag("Meteorite"))
        {
            lifeManager.DecreaseLives();
            Destroy(collision.gameObject);
            collisionSound.Play();
        }

        if (collision.gameObject.CompareTag("Fruit1"))
        {
            Destroy(collision.gameObject);
            score += 15;
            UpdateScoreText();
            scoreSound.Play();
        }
        if (collision.gameObject.CompareTag("Fruit2"))
        {
            Destroy(collision.gameObject);
            score += 20;
            UpdateScoreText();
            scoreSound.Play();
        }
        if (collision.gameObject.CompareTag("Fruit3"))
        {
            Destroy(collision.gameObject);
            score += 25;
            UpdateScoreText();
            scoreSound.Play();
        }
    }

    private void UpdateScoreText()
    {
        string scoreValue = score.ToString();
        ScoreText.text = "очки " + scoreValue;
        ScoreText2.text = "Набранные очки " + scoreValue;

        if (score > bestScore)
        {
            bestScore = score;
            BestScoreText.text = "Рекорд  " + bestScore.ToString();
            BestScoreText2.text = "Рекорд  " + bestScore.ToString();

           
            PlayerPrefs.SetInt("Рекорд", bestScore);
        }
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
        ScoreText2.text = "Набранные очки " + score.ToString();
    }

    public void ResetLives()
    {
        lifeManager.ResetLives();
    }

  
}
