using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class EnemyAI : MonoBehaviour
{
    public static bool movement = true;

    private Transform target;
    public static float speed = 1;
    public float stoppingDistance = 2;
    public static int enemyHealth = 100;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < stoppingDistance && movement)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (enemyHealth <= 0)
        {
            Destroy(GameObject.Find("Enemy"));
        }
    }
   
}
