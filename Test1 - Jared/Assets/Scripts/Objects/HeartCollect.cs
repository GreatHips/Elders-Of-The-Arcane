using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollect : MonoBehaviour
{
    public GameObject player;
    HealthManager healthManager;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player && player.GetComponent<HealthManager>().health < player.GetComponent<HealthManager>().healthMax)
        {
            
            player.GetComponent<HealthManager>().Heal(20);
            Destroy(gameObject);
        } else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
