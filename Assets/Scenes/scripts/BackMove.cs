using UnityEngine;

public class BackMove : MonoBehaviour
{
    public float scrollSpeed = 1f; 
    private Renderer backgroundRenderer; 

    private void Start()
    {
       
        backgroundRenderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        
        float offset = Time.time * scrollSpeed;

       
        backgroundRenderer.material.mainTextureOffset = new Vector2(offset, 0f);
    }
}
