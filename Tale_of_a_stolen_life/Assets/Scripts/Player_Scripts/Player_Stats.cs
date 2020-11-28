using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Player_Stats : MonoBehaviour
{
    public float  health = 100, maxHealth = 100;
    private GameObject hand; 
    public Image bar; 
    void Start()
    {
        hand = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        bar.fillAmount = health / maxHealth;
        if (health <= 0)
            Camera.main.GetComponent<UIManager>().Lose();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
