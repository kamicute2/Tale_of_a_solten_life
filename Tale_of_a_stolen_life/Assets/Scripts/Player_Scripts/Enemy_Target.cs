using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Target : MonoBehaviour
{
    public bool isLeft = true, isRight = true;
    int Right = -10, Left = -11;
    private Transform playerTransform;
    private GameObject[] enemies;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        //enemies = [];
        //Поиск объектов с тегом "Enemy"
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        if (enemies.Length > 0)
        {   
            Right = Random.Range(0, enemies.Length);
            Left = Random.Range(0, enemies.Length);
            
        }
        if (Right > -1 && enemies[Right].GetComponent<EnemyAI>().points != 0 || Right == Left)
                        Right = (Right + 1) % enemies.Length;
        if (isRight && Right > -1 && enemies[Right].GetComponent<EnemyAI>().isPoint)
        {
            enemies[Right].GetComponent<EnemyAI>().isRight = true;
        }

        if (Left > -1 && enemies[Left].GetComponent<EnemyAI>().points != 0 || Right == Left)
                        Left = (Left + 1) % enemies.Length;
        if (isLeft && Left > -1 && enemies[Left].GetComponent<EnemyAI>().isPoint)
        {
            enemies[Left].GetComponent<EnemyAI>().isLeft = true;
        }
        Left = -11;
        Right = -10;
    }
}
        
           
       //Debug.Log(enemies.Length);
       // Debug.Log("l"+ enemies[Left].GetComponent<EnemyAI>().isRight);

    

