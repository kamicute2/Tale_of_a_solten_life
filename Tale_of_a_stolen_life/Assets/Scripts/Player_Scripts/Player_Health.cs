using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public int health = 100, maxHealth = 100;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ApplyDamage(int damage)
    {
        health -= damage;
        if (health < 0)
            Destroy(gameObject);
    }
}
