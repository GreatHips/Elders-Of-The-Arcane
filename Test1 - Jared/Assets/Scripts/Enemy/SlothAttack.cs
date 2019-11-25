using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
    public class SlothAttack : EnemyAI
{
    private bool slothNotAttacked = true;
    private bool slothAttacked = false;
    private bool slothAttacking;
    new void Start()
    {
        movementSpeed = 0.0f;
        anime = GetComponent<Animator>();
        player = GameObject.Find("Player");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    new void Update()
    {
        if (facingRight)
        {
            intFacingRight = -1;
        } else if (!facingRight)
        {
            intFacingRight = 1;
        }
        Distance();

        dist = Math.Abs(Vector3.Distance(target.position, transform.position));
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        // Boss Parameters
        if (gameObject.tag == "SlothBoss" && gameObject.GetComponent<HealthManager>().health < gameObject.GetComponent<HealthManager>().healthMax)
        {
            movementSpeed = .75f;
            anime.SetBool("Awake", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
            if (movement && inDist)
            {
                if ((player.transform.position.x > transform.position.x) && facingRight == true && inDist)
                {
                    transform.Rotate(Vector3.up * 180);
                    facingRight = false;
                }
                else if ((player.transform.position.x <= transform.position.x) && facingRight == false && inDist)
                {
                    transform.Rotate(Vector3.up * 180);
                    facingRight = true;
                }
            }
            if (slothNotAttacked)
            {
                
                StartCoroutine(SlothBossAttack());
            }

        }
    }
    IEnumerator SlothBossAttack()
    {
        if (slothNotAttacked)
        {
            slothNotAttacked = false;

            //SLOTH NEEDS TO BE DONE COMPLETELY
            yield return new WaitForSeconds(UnityEngine.Random.Range(3, 8));
            var number = UnityEngine.Random.Range(1, 1);
            Debug.Log(number);
            if (number == 1 && !slothAttacking)
            {
               
            }
            if (number == 2 && !slothAttacking)
            {
                

            }
            if (number == 3 && !slothAttacking)
            {
               
            }
            if (number == 4 && !slothAttacking)
            {
             
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage(30, 15, 35, collision);
    }
}
