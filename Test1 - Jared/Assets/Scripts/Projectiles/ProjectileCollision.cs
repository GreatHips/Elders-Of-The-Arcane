using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    private AudioSource iceSound;
    public AudioClip iceClip;

    private void Start()
    {
        GameObject iceSource = GameObject.Find("IceSound");

        iceClip = Resources.Load<AudioClip>("Ice_Crashing");
    }
    void OnCollisionEnter2D(Collision2D coll)
    { 

        //when touching obstacle destroy the bullet
        if (coll.gameObject.tag == "Obstacle" && gameObject.tag != "Ice")
        {
            Destroy(gameObject);
        }
        //when touching lava destroy the bullet
        if (coll.gameObject.tag == "Lava")
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
        if (coll.gameObject.tag == "Obstacle" && gameObject.tag == "Ice")
        {
            iceSound.PlayOneShot(iceClip, .75f);

            Destroy(gameObject);
        }
    }
}
