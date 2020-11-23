using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Script : MonoBehaviour
{
    public Vector2 speed = new Vector2(3, 1);
    public Vector2 direction = new Vector2(-1, 0);
    private Vector2 movement;
    private Rigidbody2D rb;
    //public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        rb.gravityScale = 0;
        rb.drag = 9;
    }
    void Update()
    {
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
    }

    void FixedUpdate()
    {
        rb.velocity = movement;
        //if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)))
        //{
        //    animator.SetBool("Player_run", true);
        //}
        //else
        //{
        //    animator.SetBool("Player_run", false);
        //}
    }
}
