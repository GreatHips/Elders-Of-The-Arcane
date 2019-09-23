using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public GameObject enemyHpBar;
    void OnCollisionEnter2D(Collision2D coll)

    {

        if (coll.gameObject.tag == "Enemy")
        {
            Damage(20);
            Destroy(GameObject.Find("Light(Clone)"), 0.01f);
            Destroy(gameObject);
            enemyHpBar.SetActive(true);
        }
        if (coll.gameObject.tag == "Bullets")
        {
            Debug.Log("touching clone");
            Destroy(GameObject.Find("Light(Clone)"));
        }
        if (coll.gameObject.tag == "Obstacle")
        {
            Destroy(GameObject.Find("Light(Clone)"));
        }

    }


    void Damage(int damage)
    {
        EnemyAI.enemyHealth -= damage;
        Debug.Log("Enemy hp: " + EnemyAI.enemyHealth);
        
    }
}
