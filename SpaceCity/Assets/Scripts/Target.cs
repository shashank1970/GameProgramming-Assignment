﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public float points = 10f;
   
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
          
            Die();
        }
    }




    void Die()
    {

        Score.score += points;
        Destroy(gameObject);
      
    }
}
