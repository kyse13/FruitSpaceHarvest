using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public float acceleration = 5f;
    public float deceleration = 10f;
    public float maxSpeed = 10f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector2(moveHorizontal, moveVertical).normalized;
    }

    private void FixedUpdate()
    {
        if (movement.magnitude > 0)
        {
            rb.AddForce(movement * acceleration);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, deceleration * Time.fixedDeltaTime);
        }

        float cameraWidth = Camera.main.orthographicSize * Camera.main.aspect - 0.7f;
        float cameraHeight = Camera.main.orthographicSize - 0.7f;

        
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -cameraWidth, cameraWidth);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -cameraHeight, cameraHeight);
        transform.position = clampedPosition;
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.rotation = 0f;
    }
}
 