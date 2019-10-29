using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(EnemyController))]
public class EnemyAI : HealthBar
{
    
    public static bool movement = true;
    public float movementSpeed = 2.0f;
    public float stoppingDistance = 250f;
    public bool facingRight = true;
    public bool canJump = true;
    [HideInInspector]
    public Rigidbody2D myRigidBody;
    [HideInInspector]
    public Animator anime;
    [HideInInspector]
    public Transform target;
    public bool isJumping = false;
    public float dist;
    public bool inDist;

    public void Start()
    {
        anime = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        myRigidBody = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        dist = Math.Abs(Vector3.Distance(target.position, transform.position));
        if (dist <= stoppingDistance)
        {
            inDist = true;
        }
        else if (dist > stoppingDistance)
        {
            inDist = false;
        }
    }
  
 
    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }


}
