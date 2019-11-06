using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class eyeDemon : EnemyAI
{
    private GameObject player;
    new void Start()
    {
        anime = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Distance();

        if (movement && inDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
            anime.SetBool("Chase", true);

        }
        else if (!inDist)
        {
            anime.SetBool("Chase", false);
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
}
