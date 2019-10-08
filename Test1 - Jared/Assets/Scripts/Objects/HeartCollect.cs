using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollect : HealthManager
{
    public GameObject player;
    Player playerClass;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && health < healthMax)
        {
            Heal(50);
            Destroy(this);
        } else
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
