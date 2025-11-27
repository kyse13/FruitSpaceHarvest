using UnityEngine;

public class MeteorRemove : MonoBehaviour
{
    public RectTransform removalPosition; 

    private float targetXPosition; 

    public void Start()
    {
        
        if (removalPosition != null)
        {
            targetXPosition = removalPosition.position.x;
        }
        else
        {
            Debug.LogWarning("Объект removalPosition не назначен.");
        }
    }

    public void Update()
    {
       
        if (transform.position.x <= targetXPosition)
        {
            
            Destroy(gameObject);
        }
    }
}
