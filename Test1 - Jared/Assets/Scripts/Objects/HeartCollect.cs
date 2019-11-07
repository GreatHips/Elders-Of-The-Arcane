using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollect : MonoBehaviour
{
    private GameObject player;
    HealthManager healthManager;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
    
            if (player.GetComponent<HealthManager>().health < player.GetComponent<HealthManager>().healthMax)
            {
                player.GetComponent<HealthManager>().Heal(75);
                Destroy(gameObject);
            }
        } else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
