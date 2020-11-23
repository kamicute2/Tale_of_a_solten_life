﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2; 
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
            Destroy(gameObject);
        }
    }
}
