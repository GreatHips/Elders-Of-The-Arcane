using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health = 100;
    public int healthMax = 100;


    void Start()
    {
        // on start set health to their max health to reset values
        health = healthMax;
    }
  
    void Update()
    {
        //if health goes over max, reset it to the max
        if (health > healthMax)
        {
            health = healthMax;
        }

        //destroys object upon losing all health
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //returns the health value
    public int GetHealth()
    {
        return health;
    }


    //subtract damage from health
    public void Damage(int damageAmount)
    {
         health -= damageAmount;
    }

    //add health to the total amount of health
    public void Heal(int healAmount)
    {
        health += healAmount;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if the collision is from a bullet and it hits an object tagged with enemy, take 50 damage
        if (collision.gameObject.tag == "Bullets" && gameObject.tag == "Slime")
        {
            Damage(50);
        }

        if (collision.gameObject.tag == "Bullets" && gameObject.tag == "Boar")
        {
            Damage(25);
        }
        // if the collision is from a bullet and it hits an object tagged with Boss, take 25 damage
        if (collision.gameObject.tag == "Bullets" && gameObject.tag == "SlothBoss")
        {
            Damage(25);
        }

        if (collision.gameObject.tag == "Bullets" && gameObject.tag == "eyeDemon")
        {
            Damage(25);
        }

        // if the collision is from an enemy, and it hits an obect tagged Player, take 20 damage
        if (collision.gameObject.tag == "Slime" && gameObject.tag == "Player")
        {
            Damage(15);
        }

        // if the collision is from an boss, and it hits an obect tagged Player, take 20 damage
        if (collision.gameObject.tag == "SlothBoss" && gameObject.tag == "Player")
        {
            Damage(35);
        }

        if (collision.gameObject.tag == "Boar" && gameObject.tag == "Player")
        {
            Damage(20);
        }
        if (collision.gameObject.tag == "eyeDemon" && gameObject.tag == "Player")
        {
            Damage(25);
        }
    }
}
