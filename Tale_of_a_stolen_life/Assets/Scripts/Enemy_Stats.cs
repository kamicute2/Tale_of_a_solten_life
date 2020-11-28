using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Stats : MonoBehaviour
{
    private GameObject player;
    public Image bar;
    public int health = 2, maxHealth = 5;
    private Transform tr;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tr = GetComponent<Transform>();
        
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
        
        if (health <= 0)
        {
            if (GetComponent<EnemyAI>().isRight)
            {
                player.GetComponent<Enemy_Target>().isRight = true;
            }
            if (GetComponent<EnemyAI>().isLeft)
            {
                player.GetComponent<Enemy_Target>().isLeft = true;
            }
            if (tr.gameObject.name == "Boss(Clone)")
                Camera.main.GetComponent<UIManager>().Win();

            Destroy(gameObject);
            
        }
    }
}
