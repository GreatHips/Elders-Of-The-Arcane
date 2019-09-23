using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D coll)

    {

        if (coll.gameObject.tag == "Enemy")
        {
            Damage();
            Destroy(GameObject.Find("Light(Clone)"), 0.01f);
            Destroy(gameObject);
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


    void Damage()
    {
        EnemyAI.enemyHealth -= 50;
        Debug.Log("Enemy hp: " + EnemyAI.enemyHealth);
        
    }
}
