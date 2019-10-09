using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollect : MonoBehaviour
{
    public GameObject player;
    HealthManager healthManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player && healthManager.health < healthManager.healthMax)
        {
            player.GetComponent<HealthManager>().Heal(20);
            Destroy(gameObject);
        } else
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
