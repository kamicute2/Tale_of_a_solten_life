using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    public float  health = 100, maxHealth = 100;
    private GameObject hand; 
    void Start()
    {
        hand = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        
    }
}
