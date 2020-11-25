using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stats : MonoBehaviour
{
    private GameObject player;
    public int health = 5;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    void Start()
    {
        
    }
    void Update()
    {
        if(health <= 0)
        {
            if (GetComponent<EnemyAI>().isRight)
            {
                player.GetComponent<Enemy_Target>().isRight = true;
            }
            if (GetComponent<EnemyAI>().isLeft)
            {
                player.GetComponent<Enemy_Target>().isLeft = true;
            }
            Destroy(gameObject);
            
        }
    }
}
