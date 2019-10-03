using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth = 100;
    public static int InternalHealth = 100;


    void Start()
    {
        CurrentHealth = MaxHealth;
        InternalHealth = CurrentHealth;
    }

    void Update()
    {
        if (InternalHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}

