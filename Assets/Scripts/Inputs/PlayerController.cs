using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    float x;
    float y;
    Rigidbody2D rb;
    Collider2D collider;
    Camera cam;
    float leftCoordinateOfPlayer;
    float topCoordinateOfPlayer;
    float rightCoordinateOfPlayer;
    float bottomCoordinateOfPlayer;

    private Vector2 screenBounds;
    private float playerWidth;
    private float playerHeight;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        cam = Camera.main;
    }

    private void Start()
    {
        screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z));
        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        playerHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    private void LateUpdate()
    {
        //Clamp players position to screen bounds
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x + playerWidth, screenBounds.x - playerWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y + playerHeight, screenBounds.y - playerHeight);
        transform.position = viewPos;
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
        if (x == 0f && y == 0f)
        {
            rb.AddForce(-rb.velocity * moveSpeed);
        }
    }

    public void OnMoveInput(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
}
