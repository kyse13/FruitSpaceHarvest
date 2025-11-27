using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenAdaptiveObject : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 initialScale;

    private void Start()
    {
       
        initialPosition = transform.position;
        initialScale = transform.localScale;

        
        AdaptToScreenSize();
    }

    private void AdaptToScreenSize()
    {
      
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

       

        float newWidth = initialScale.x * screenWidth / Screen.dpi;


        float newHeight = initialScale.y * screenHeight / Screen.dpi;

 
        Vector3 newScale = new Vector3(newWidth, newHeight, transform.localScale.z);
        transform.localScale = newScale;

     
        transform.position = initialPosition;
    }

    private void Update()
    {
     
        AdaptToScreenSize();
    }
}
