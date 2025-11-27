using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ScaleBackground();
    }

    private void ScaleBackground()
    {
        if (spriteRenderer == null)
        {
            Debug.LogWarning("SpriteRenderer not found!");
            return;
        }

        float cameraHeight = Camera.main.orthographicSize * 2f;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        Vector3 newScale = new Vector3(cameraWidth / spriteRenderer.bounds.size.x, cameraHeight / spriteRenderer.bounds.size.y, 1f);
        transform.localScale = newScale;
    }
}
