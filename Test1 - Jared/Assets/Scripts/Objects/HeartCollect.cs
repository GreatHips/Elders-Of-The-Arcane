using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollect : MonoBehaviour
{
    public GameObject heart;
    public GameObject player;
    Player playerClass;

    HealthManager healthManager;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 && healthManager.health < healthManager.healthMax)
        {
            healthManager.Heal(50);
            Object.Destroy(heart);
        } else
        {
            heart.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
