using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Beat : MonoBehaviour
{

    public Transform BeatPos;
    public LayerMask enemy;
    public float beatRange;
    public int damage;
    public Animator animator;
    public bool isAttacking = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if ((Input.GetButtonDown("Fire1")) && !isAttacking)
        {
            isAttacking = true;
            animator.Play("Player_beat");
        }
    }
    public void OnBeat()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(BeatPos.position, beatRange, enemy);
        for (int i = 0; i <= enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy_Stats>().TakeDamage(damage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(BeatPos.position, beatRange);
    }
}
