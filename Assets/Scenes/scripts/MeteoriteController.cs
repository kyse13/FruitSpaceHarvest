using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    public LifeManager lifeManager; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerShip"))
        {
            lifeManager.DecreaseLives(); 
            Destroy(gameObject); 
        }
    }
}
