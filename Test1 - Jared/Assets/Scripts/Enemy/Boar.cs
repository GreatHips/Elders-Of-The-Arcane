using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boar : EnemyAI
{
    private GameObject player;
    new void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myRigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    new void Update()
    {
        Distance();

        if (movement && inDist)
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
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
            player.GetComponent<HealthManager>().Damage(20);
        }
    }
}
