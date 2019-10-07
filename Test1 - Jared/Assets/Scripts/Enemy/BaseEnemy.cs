using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseEnemy : MonoBehaviour
{

    public GameObject EnemyPrefab;
    public float MaxHealth;
    public int EnemyDamage;

    public float updatedHealth;
    private float randX;
    private float spawnRate = 2f;
    private float TheNumber;
    Player player;
    Vector2 whereToSpawn;

    
    public float _currentHealth;
    public float newHealthValue;

    public void UpdateHealth(float newHealthValue)
    {
        _currentHealth = newHealthValue;
    }
    public void StartEnemyHealthValue(float enemyHealth)
    {
        MaxHealth = enemyHealth;
        _currentHealth = MaxHealth;

    }
    public void ReceiveDamage(int damage)
    {
        updatedHealth = _currentHealth - damage;

    }

    public void EnemySpawner(float enemyHealth, float maxEnemyHealth)
    {

        
        TheNumber = Time.time + spawnRate;
        randX = UnityEngine.Random.Range(-8.4f, 8.4f);
        whereToSpawn = new Vector2(randX, transform.position.y);

        var clone = Instantiate(EnemyPrefab, whereToSpawn, Quaternion.identity);
        clone.transform.parent = transform;
        
    }
}

