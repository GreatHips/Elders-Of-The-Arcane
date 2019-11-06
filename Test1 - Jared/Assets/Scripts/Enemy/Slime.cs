using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Slime : EnemyAI
{
    private GameObject player;
    HealthManager healthTotal;

    private new void Start()
    {
        health = 50;
        healthMax = 50;
        health = healthMax;
        player = GameObject.Find("Player");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anime = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        var healthTotal = GetComponent<HealthManager>();
        
    }

    // Update is called once per frame
    new void Update()
    {
        Distance();
        if (movement && inDist && movement)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
            anime.SetBool("SlimeJump", true);
        }
        else
        {
            anime.SetBool("SlimeJump", false);
        }

        if ((target.position.y >= transform.position.y) && myRigidBody.velocity.y == 0 && (Math.Abs(target.position.x - this.transform.position.x) < 20) && inDist && !isJumping)
        {
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, 7.25f, 0); ;
            StartCoroutine(WaitJump());
        }
        if ((target.position.x > transform.position.x) && facingRight == true && inDist)
        {
            transform.Rotate(Vector3.up * 180);
            facingRight = false;
        }
        else if ((target.position.x <= transform.position.x) && facingRight == false && inDist)
        {
            transform.Rotate(Vector3.up * 180);
            facingRight = true;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<HealthManager>().Damage(30);
            movement = false;
            StartCoroutine(WaitMov(1.25f));
        }
        if (collision.gameObject.tag == "FireBall")
        {
            GetComponent<HealthManager>().Damage(30);
        }
        if (collision.gameObject.tag == "Ice")
        {
            GetComponent<HealthManager>().Damage(15);
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
  
}
