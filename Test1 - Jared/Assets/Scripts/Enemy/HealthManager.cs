using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health = 100;
    public int healthMax = 100;

    public static int staticNewHealth;
    public static int staticHealth;

    void Start()
    {
        
        health = healthMax;
    }
  
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Hp: " + GetHealth());
    }

    public int GetHealth()
    {
        return health;
    }

    public static void UpdateHealth()
    {
        staticNewHealth = staticHealth;
    }

    public void Damage(int damageAmount)
    {
         health -= damageAmount;
        staticHealth = health;
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        staticHealth = health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullets")
        {
            Damage(20);
        }
    }
}
