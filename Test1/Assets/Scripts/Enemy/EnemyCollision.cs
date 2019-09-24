using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameObject enemyHpBar;
    public GameObject ActualEnemy;
    EnemyHealthManager enemyHealth;
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullets")
        {
            EnemyHealthManager.InternalHealth -= 20;
        }
    }
}
