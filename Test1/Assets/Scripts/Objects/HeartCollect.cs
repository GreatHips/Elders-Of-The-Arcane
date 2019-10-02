using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollect : MonoBehaviour
{
    public GameObject heart;
    public GameObject player;
    Player playerClass;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 && Player.globalHealth < 3)
        {
            Player.globalHealth += 1;
            Object.Destroy(heart);
        } else
        {
            heart.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
