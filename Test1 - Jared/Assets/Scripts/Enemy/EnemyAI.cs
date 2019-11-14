﻿using System.Collections;
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
    [HideInInspector]
    public GameObject player;
    public Vector3 velocity;
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

        if (movement && inDist)
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
            if(gameObject.tag == "Slime") {
                anime.SetBool("SlimeJump", true);
            }
            if (gameObject.tag == "eyeDemon")
            {
                anime.SetBool("Chase", true);
            }
            if (gameObject.tag == "Boar")
            {
                anime.SetBool("Attacking", true);
            }
        }
        else if (!inDist)
        {
            if (gameObject.tag == "Slime")
            {
                anime.SetBool("SlimeJump", false);
            }
            if (gameObject.tag == "eyeDemon")
            {
                anime.SetBool("Chase", false);
            }
            if (gameObject.tag == "Boar")
            {
                anime.SetBool("Attacking", false);
            }
        }
        if (gameObject.tag == "Slime")
        {
            if ((target.position.y >= transform.position.y) && myRigidBody.velocity.y == 0 && (Math.Abs(target.position.x - this.transform.position.x) < 20) && inDist && !isJumping)
            {
                myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, 7.25f, 0); ;
                StartCoroutine(WaitJump());
            }
        }

        if ((target.position.x < transform.position.x) && facingRight == true && inDist)
        {
            transform.Rotate(Vector3.up * 180);
            facingRight = false;
        }
        else if ((target.position.x > transform.position.x) && facingRight == false && inDist)
        {
            transform.Rotate(Vector3.up * 180);
            facingRight = true;
        }
    }

    IEnumerator WaitJump()
    {
        isJumping = true;
        if (isJumping)
        {
            GetComponent<Animation>().enabled = true;
        }
        else if (!isJumping)
        {
            GetComponent<Animation>().enabled = false;
        }
        yield return new WaitForSeconds(2);

        isJumping = false;
    }
    public IEnumerator WaitMov(float Seconds)
    {
        yield return new WaitForSeconds(Seconds);
        movement = true;
    }
    public void TakeDamage(int FireDamage, int IceDamage, int PlayerDamage, Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<HealthManager>().Damage(PlayerDamage);
            movement = false;
            StartCoroutine(WaitMov(1.25f));
        }

        if (collision.gameObject.tag == "FireBall")
        {
            GetComponent<HealthBar>().Damage(FireDamage);
        }
        if (collision.gameObject.tag == "Ice")
        {
            GetComponent<HealthManager>().Damage(IceDamage);
        }
    }
    public void enemyParameterCheck()
    {
        player = GameObject.Find("Player");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anime = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }
}
