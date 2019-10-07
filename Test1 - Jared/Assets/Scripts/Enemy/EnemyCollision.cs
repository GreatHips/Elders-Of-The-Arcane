using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameObject enemyHpBar;
    public GameObject ActualEnemy;
    BaseEnemy baseEnemy;
    HealthManager healthManager;

    void Update()
    {
        if (healthManager.health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullets")
        {
          
            
        }
    }
}
