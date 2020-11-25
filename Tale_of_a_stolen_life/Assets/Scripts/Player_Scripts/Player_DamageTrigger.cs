using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_DamageTrigger : MonoBehaviour
{
    private bool isAttacking = false;
    private string collisionName = "";
    void Start()
    {

    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Эта часть ищет объект с тегом "Enemy" и отнимает у него здоровье, переходя в режим ожидания
        if (collision.gameObject.tag == "Enemy" && !isAttacking)
        {
            collisionName = collision.gameObject.name;
            isAttacking = true;
            collision.GetComponent<Enemy_Stats>().TakeDamage(1);
            //Debug.Log(collision.gameObject.name);
            //collision.gameObject.SendMessage("ApplyDamage", 10);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Эта часть проверяет объект, из которого "выходит" наш коллайдер и, если имена одинаковы, выводит скрипт из режима ожидания
        if(collision.gameObject.name == collisionName && isAttacking)
        {
            isAttacking = false;
        }
    }
}
