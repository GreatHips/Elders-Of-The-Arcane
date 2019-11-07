using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
    [RequireComponent(typeof(EnemyController))]
public class EnemyAI : HealthBar
{
    //Makes variables
    public bool movement = true;
    public float movementSpeed = 2.0f;
    public float stoppingDistance = 13f;
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

    public int intFacingRight;
    public new void Update()
    {
        if (facingRight)
        {
            intFacingRight = -1;
        }
        else if (!facingRight)
        {
            intFacingRight = 1;
        }
    }
    public void Start()
    {
        anime = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        myRigidBody = GetComponent<Rigidbody2D>();
        
    }
    public void Distance()
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

    public IEnumerator WaitMov(float Seconds)
    {
        yield return new WaitForSeconds(Seconds);
        movement = true;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
