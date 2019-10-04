using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameObject enemyHpBar;
    public GameObject ActualEnemy;
    BaseEnemy baseEnemy;

    new void Update()
    {
        if (baseEnemy._currentHealth <= 0)
        {
            Destroy(this);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullets")
        {
            baseEnemy._currentHealth -= 20;
            
        }
    }
}
