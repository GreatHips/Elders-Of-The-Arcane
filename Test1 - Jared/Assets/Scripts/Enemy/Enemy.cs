using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseEnemy
{ 
    public new void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            EnemySpawner(Random.Range(100, 200), 200);
            EnemySpawner(100, 100);
        }  
    }
}