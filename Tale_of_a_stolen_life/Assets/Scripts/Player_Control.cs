using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    public Vector2 speed = new Vector2(3, 1);
    private Vector2 movement;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float movex = Input.GetAxis("Horizontal");
        float movey = Input.GetAxis("Vertical");
        movement = new Vector2(speed.x * movex, speed.y * movey);
    }

    void FixedUpdate()
    {
        rb.velocity = movement;
        rb.gravityScale = 0;
        rb.drag = 9;
    }
}
