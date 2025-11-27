using UnityEngine;

public class FruitMovement : MonoBehaviour
{
    public float movementSpeed = 2f; 
    public RectTransform removalPosition; 
    private Vector3 movementDirection;

    void Update()
    {
        
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);

        
        if (transform.position.x < removalPosition.position.x)
        {
            Destroy(gameObject);
        }
    }

    public void SetMovementDirection(Vector3 direction)
    {
        movementDirection = direction;
    }
}
