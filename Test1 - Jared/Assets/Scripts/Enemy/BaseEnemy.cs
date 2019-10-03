using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseEnemy : MonoBehaviour
{
    public GameObject EnemyType;
    public GameObject EnemyPrefab;
    public string EnemyTag;
    public int MaxHealth;
    public int EnemyDamage;
    public Vector3 SpawnPos;

    private int _currentHealth;

    public void Init()
    {
        _currentHealth = MaxHealth;
    }


    public void UpdateHealth(int newHealthValue)
    {
        _currentHealth = newHealthValue;
    }

    public void ReceiveDamage(int damage)
    {
        var updatedHealth = _currentHealth - damage;
        UpdateHealth(updatedHealth > 0 ? updatedHealth : 0);
    }
}

