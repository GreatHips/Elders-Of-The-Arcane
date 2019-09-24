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
            Destroy(GameObject.Find("Fireball(Clone)"));
        }
        if (coll.gameObject.tag == "Obstacle")
        {
            Destroy(GameObject.Find("Fireball(Clone)"));
        }
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }


    
}
