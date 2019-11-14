using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Slime : EnemyAI
{
    
    private new void Start()
    {
        enemyParameterCheck();
    }
    new void Update()
    {
        
        Distance();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        TakeDamage(30, 15, 20, collision);
    }

  
}
