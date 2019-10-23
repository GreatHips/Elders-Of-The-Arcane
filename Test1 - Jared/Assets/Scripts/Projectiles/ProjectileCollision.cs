using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D coll)

    { 
        //if collision with a clone of the bullets, destroy it
        if (coll.gameObject.tag == "Bullets")
        {
            Debug.Log("touching clone");
            Destroy(gameObject);
        }

        //when touching obstacle destroy the bullet
        if (coll.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
        //on touching enemy, destroy bullet
        if (coll.gameObject.layer == 10)
        {
            Destroy(gameObject);
        }

        // on touching boss destroy bullet
        if (coll.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        //if it stays in the collider of an obstacle destroy the bullet
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
