using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Target : MonoBehaviour
{
    public bool isLeft = true, isRight = true;
    float minDistLeft = 10000f, minDistRight = 10000f;
    int minDistRightEnemy = -10, minDistLeftEnemy = -11;
    private Transform playerTransform;
    private GameObject[] enemies;

    // Start is called before the first frame update
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
            //Поиск ближайшего к правой точке объекта
            for(int i = 0; i < enemies.Length; i++)
            { 
                if(Vector3.Distance(enemies[i].GetComponent<Transform>().position, new Vector3(playerTransform.position.x + 1f, playerTransform.position.y, playerTransform.position.z)) < minDistRight && isRight)
                {
                    minDistRight = Vector3.Distance(enemies[i].GetComponent<Transform>().position, new Vector3(playerTransform.position.x + 1f, playerTransform.position.y, playerTransform.position.z));
                    minDistRightEnemy = i;   
                }
            }
            
            
            //Поиск ближайшего к левой точке объекта
            for (int i = 0; i < enemies.Length; i++)
            {
                if (Vector3.Distance(enemies[i].GetComponent<Transform>().position, new Vector3(playerTransform.position.x - 1f, playerTransform.position.y, playerTransform.position.z)) < minDistLeft && isLeft)
                {
                    minDistLeft = Vector3.Distance(enemies[i].GetComponent<Transform>().position, new Vector3(playerTransform.position.x - 1f, playerTransform.position.y, playerTransform.position.z));
                    minDistLeftEnemy = i;
                }
            }
            if (isRight)
            {
                if (enemies[minDistRightEnemy].GetComponent<EnemyAI>().points != 0 || minDistRightEnemy == minDistLeftEnemy)
                    minDistRightEnemy = (minDistRightEnemy + 1) % enemies.Length;
                enemies[minDistRightEnemy].GetComponent<EnemyAI>().isRight = true;
                minDistRight = 100000f;
                //minDistRightEnemy = -10;
            }
           // if (minDistRightEnemy == minDistLeftEnemy)
            //    minDistLeftEnemy = (minDistLeftEnemy + 1) % enemies.Length;

            if (isLeft)
            {
                if(enemies[minDistLeftEnemy].GetComponent<EnemyAI>().points != 0 || minDistRightEnemy == minDistLeftEnemy)
                    minDistLeftEnemy = (minDistLeftEnemy + 1) % enemies.Length;
                enemies[minDistLeftEnemy].GetComponent<EnemyAI>().isLeft = true;
                minDistLeft = 100000f;
                //minDistLeftEnemy = -11;
            }
        }
        
           
       //Debug.Log(enemies.Length);
       // Debug.Log("l"+ enemies[minDistLeftEnemy].GetComponent<EnemyAI>().isRight);

    }
}
