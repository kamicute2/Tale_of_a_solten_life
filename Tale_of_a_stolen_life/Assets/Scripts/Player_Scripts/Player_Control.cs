using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    //Переменные для атаки
    public Transform BeatPos;
    public LayerMask enemy;
    public int damage;
    public bool isAttacking = false;
    //Переменные для передвижения
    public Vector2 speed = new Vector2(3, 1);
    private Vector2 movement;
    //private bool isGrounded = true;
    bool isJumping = false;
    //Прочие штуки
    private Rigidbody2D rb;
    public Animator animator;
    public GameObject attackHitBox;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        attackHitBox.SetActive(false); 
        rb.gravityScale = 0;
        rb.drag = 1;
    }
    void Update()
    {
        float movex = Input.GetAxis("Horizontal");
        float movey = Input.GetAxis("Vertical");
        movement = new Vector2(speed.x * movex, speed.y * movey);
        //Атака
        if ((Input.GetButtonDown("Fire1")) && !isAttacking)
        {
            isAttacking = true;
            animator.Play("Player_beat");
            StartCoroutine(DoAttack());

        }
        //Прыжок
        if ((Input.GetKeyDown(KeyCode.Space)) && (!isAttacking) && (!isJumping))
        {
            rb.velocity = new Vector2(0, 0);
            isJumping = true;
            if ((isJumping) && (Input.GetKey(KeyCode.D)))
                rb.velocity = new Vector2(2, 0);
            else if ((isJumping) && (Input.GetKey(KeyCode.A)))
                rb.velocity = new Vector2(-2, 0);
            animator.Play("Player_jump");
            //rb.velocity = new Vector2(speed.x * movex, rb.velocity.y);
            StartCoroutine(DoJump());
            //РЕАЛИЗУЙ, МАТЬ ТВОЮ, ЗДЕСЬ ПРЫЖОК
            //rb.velocity =  Vector2.up * jumpForce;
            //StartCoroutine(DoJump());
            //ПАШОЛ НАХУЙ
        }
    } 

    void FixedUpdate()
    {

        if ((!isAttacking) && (!isJumping))
            rb.velocity = movement;
        if (isAttacking)
            rb.velocity = new Vector2(0, 0);

        if ((Input.GetKey(KeyCode.D)))
            {
                if ((!isAttacking) && (!isJumping))
                {
                    transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                    animator.Play("Player_run");
                }

            }
            else if (Input.GetKey(KeyCode.A))
            {
                if ((!isAttacking) && (!isJumping))
                {
                    transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
                    animator.Play("Player_run");
                }
            }
            else if ((Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.W)))
            {
                if ((!isAttacking) && (!isJumping))
                {
                    animator.Play("Player_run");
                }
            }
            else
            {
                if (!isJumping)
                {
                    if (!isAttacking)
                    {
                        animator.Play("Player_Idle");
                        rb.velocity = new Vector2(0, 0);
                    }
                }
            }
    }
    IEnumerator DoAttack()
    {
        attackHitBox.SetActive(true);
        yield return new WaitForSeconds(0.23f);
        attackHitBox.SetActive(false);
        isAttacking = false;
    }
    IEnumerator DoJump()
    {     
        yield return new WaitForSeconds(0.9f);
        isJumping = false;
    }

    public void OnBeat()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(BeatPos.position, enemy);
        for (int i = 0; i <= enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy_Stats>().TakeDamage(damage);
        }
    }
}
