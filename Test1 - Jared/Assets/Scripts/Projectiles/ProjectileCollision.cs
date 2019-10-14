using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D coll)

    {
        if (coll.gameObject.tag == "Bullets")
        {
            Debug.Log("touching clone");
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
