using UnityEngine;

public class FruitRemove : MonoBehaviour
{
    public LifeManager lifeManager; 
    public AudioSource fruitDisappearSound; 
    public RectTransform removalPosition; 

    private float targetXPosition;

    public void Start()
    {
       
        lifeManager = FindObjectOfType<LifeManager>();

        
        if (lifeManager == null)
        {
            Debug.LogWarning("LifeManager не найден в сцене.");
        }

        if (removalPosition != null)
        {
            targetXPosition = removalPosition.position.x;
        }
        else
        {
            Debug.LogWarning("Объект removalPosition не назначен.");
        }
    }

    public void PlayFruitDisappearSound()
    {
        if (fruitDisappearSound != null)
        {
            fruitDisappearSound.Play();
        }
    }

    public void Update()
    {
       
        if (transform.position.x <= targetXPosition)
        {
            if (lifeManager != null)
            {
                lifeManager.DecreaseLives();
            }

            
            PlayFruitDisappearSound();

           
            Destroy(gameObject);
        }
    }
}
