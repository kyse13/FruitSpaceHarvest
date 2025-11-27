using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShipper : MonoBehaviour
{
    public float startCoordinate = 0f; 
    public float endCoordinate = 10f;
    public float movementSpeed = 5f; 

    private float targetCoordinate; 

    private void Start()
    {
        targetCoordinate = endCoordinate; 
    }

    private void Update()
    {
       
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetCoordinate, transform.position.y, transform.position.z), movementSpeed * Time.deltaTime);

       
        if (Mathf.Approximately(transform.position.x, targetCoordinate))
        {
            
            if (targetCoordinate == startCoordinate)
            {
                targetCoordinate = endCoordinate;
            }
            else
            {
                
                transform.position = new Vector3(startCoordinate, transform.position.y, transform.position.z);
                targetCoordinate = startCoordinate;
            }
        }
    }
}
