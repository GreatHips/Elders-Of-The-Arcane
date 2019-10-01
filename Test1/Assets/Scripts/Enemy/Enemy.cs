using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth;
    public int enemySpeed;
    public bool enemyFlight;
    public bool enemyInvincible;
    public int enemyJumpHeight;
    public bool facingRight;
    public float formerPosition;

    public GameObject player;
    void Update()
    {
         
    }
    /*
    void ActuallyFlipEnemy()
    {
        if (gameObject.transform.position.x > player.transform.position.x)
        {
            FlipEnemy();
        }
        else if (gameObject.transform.position.x <= player.transform.position.x)
        {
            FlipEnemy();
        }
        formerPosition = gameObject.transform.position.x;

    }
    void FlipEnemy()
    {
            Vector2 localScale = this.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
    }
    */
    public void EnemyAttack1()
    {

    }
}