using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollect : MonoBehaviour
{
    public GameObject player;
    HealthManager healthManager;

    public bool notMaxHealth = false;

    public void Update()
    {
        if (player.GetComponent<HealthManager>().health < player.GetComponent<HealthManager>().healthMax)
        {
            notMaxHealth = true;
        }
        if (player.GetComponent<HealthManager>().health == player.GetComponent<HealthManager>().healthMax)
        {
            notMaxHealth = false;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            {
                player.GetComponent<HealthManager>().Heal(20);
                Destroy(gameObject);
            }

        }
        if (!notMaxHealth)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

    }
}
