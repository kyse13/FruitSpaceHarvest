using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnObject
{
    public GameObject prefab;
    public float spawnChance;
    public float width = 1f; 
    public float height = 1f; 
}

public class FruitSpawner : MonoBehaviour
{
    public SpawnObject[] spawnObjects; 
    public float spawnInterval = 1f; 
    public Vector2 spawnRadius = new Vector2(5f, 5f); 
    public float minSpawnInterval = 0.5f; 
    public float maxSpawnInterval = 2f; 
    public float objectSpeed = 2f; 

    private float nextSpawnTime;

    private bool isSpeedIncreased = false; 
    private bool isSpawnIntervalDecreased = false; 

    private LifeManager lifeManager; 
    private Canvas targetCanvas; 

    
    public void SetTargetCanvas(Canvas canvas)
    {
        targetCanvas = canvas;
    }

    private void Start()
    {
        
        nextSpawnTime = Time.time + GetRandomSpawnInterval();

     
        lifeManager = GetComponentInChildren<LifeManager>();

       
        StartCoroutine(ChangeSpeedOverTime());
        StartCoroutine(ChangeSpawnIntervalOverTime());
    }

    private void Update()
    {
       
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + GetRandomSpawnInterval(); 
        }
    }

    private void SpawnObject()
    {
        
        float totalSpawnChance = 0f;
        foreach (SpawnObject spawnObject in spawnObjects)
        {
            totalSpawnChance += spawnObject.spawnChance;
        }

        float randomX = Random.Range(-spawnRadius.x, spawnRadius.x);
        float randomY = Random.Range(-spawnRadius.y, spawnRadius.y);
        Vector3 spawnPosition = transform.position + new Vector3(randomX, randomY, 0f);

        
        float randomValue = Random.Range(0f, totalSpawnChance);

        
        foreach (SpawnObject spawnObject in spawnObjects)
        {
            if (randomValue <= spawnObject.spawnChance)
            {
              
                GameObject obj = Instantiate(spawnObject.prefab, spawnPosition, Quaternion.identity);

              
                Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = Vector2.left * objectSpeed;
                }

          
                Vector3 newScale = obj.transform.localScale;
                newScale.x = spawnObject.width;
                newScale.y = spawnObject.height;
                obj.transform.localScale = newScale;

                if (targetCanvas != null)
                {
                    obj.transform.SetParent(targetCanvas.transform, false);
                }

          
                FruitRemove fruitRemove = obj.GetComponent<FruitRemove>();
                if (fruitRemove != null)
                {
                   
                    if (fruitRemove.gameObject != null)
                    {
                        fruitRemove.lifeManager = lifeManager;
                    }
                }

                break;
            }
            else
            {
                randomValue -= spawnObject.spawnChance;
            }
        }
    }

    private float GetRandomSpawnInterval()
    {
        return Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private IEnumerator ChangeSpeedOverTime()
    {
        yield return new WaitForSeconds(50f); 

        if (!isSpeedIncreased)
        {
          
            objectSpeed += 0.5f;

            if (objectSpeed >= 5f)
            {
                isSpeedIncreased = true;
            }
        }

        
        StartCoroutine(ChangeSpeedOverTime());
    }

    private IEnumerator ChangeSpawnIntervalOverTime()
    {
        yield return new WaitForSeconds(120f); 

        if (!isSpawnIntervalDecreased)
        {
        
            spawnInterval -= 1f;

            if (spawnInterval <= 1f)
            {
                isSpawnIntervalDecreased = true;
            }
        }

       
        StartCoroutine(ChangeSpawnIntervalOverTime());
    }
}
