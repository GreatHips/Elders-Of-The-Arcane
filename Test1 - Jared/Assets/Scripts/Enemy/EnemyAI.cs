using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class EnemyAI : MonoBehaviour
{
    private Transform target;
    public static bool movement = true;
    public float movementSpeed = 2.0f;
    public float stoppingDistance = 250;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (movement)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
        }

        if (target.position.y >= this.transform.position.y)
        {

        }
    }
}
