﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float enemyHealth;

    public GameObject bandit;

    public GameObject vfx;

    void Start()
    {
        
    }

    public void DeductHealth(float deductHealth)
    {
        enemyHealth -= deductHealth;
        

        if(enemyHealth <= 0)
        {
            EnemyDead();
        }
    }

    void EnemyDead()
    {
        Destroy(gameObject);
    }
}
