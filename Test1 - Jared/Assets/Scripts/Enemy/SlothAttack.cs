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
        }
        else if (!facingRight)
        {
            intFacingRight = 1;
        }
        Distance();
        if (target)
        {
            dist = Math.Abs(Vector3.Distance(target.position, transform.position));
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        // Boss Parameters
        if (target)
        {
            if (gameObject.tag == "SlothBoss" && gameObject.GetComponent<HealthManager>().health < gameObject.GetComponent<HealthManager>().healthMax)
            {
                movementSpeed = .25f;
                anime.SetBool("Awake", true);
                transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
                if (movement && inDist)
                {
                    if ((player.transform.position.x < transform.position.x) && facingRight == true && inDist)
                    {
                        transform.Rotate(Vector3.up * 180);
                        facingRight = false;
                    }
                    else if ((player.transform.position.x >= transform.position.x) && facingRight == false && inDist)
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
    } 
    //default, offset, x = 3.441797, y = -4.504251
      //default size, x = 13.01794, y = 10.27758

    //GetComponent<BoxCollider2D>().size = new Vector2();
    //GetComponent<BoxCollider2D>().offset = new Vector2();
    IEnumerator SlothBossAttack()
    {
        if (slothNotAttacked)
        {
            slothNotAttacked = false;
            
            yield return new WaitForSeconds(UnityEngine.Random.Range(2, 4));
            var number = UnityEngine.Random.Range(1, 3);
            Debug.Log(number);
            if (number == 1 && !slothAttacking)
            {
                slothAttacking = true;
                anime.SetBool("LongStretch", false);
                anime.SetBool("StretchAttack", true);
                movementSpeed = 0.0f;

                yield return new WaitForSeconds(1.75f);
                this.GetComponent<BoxCollider2D>().offset = new Vector2(-1.084347f, -5.819191f);
                this.GetComponent<BoxCollider2D>().size = new Vector2(22.07023f, 7.647701f); 

                //reset collider to normal
                yield return new WaitForSeconds(1f);
                this.GetComponent<BoxCollider2D>().offset = new Vector2(3.441797f, -4.504251f);
                this.GetComponent<BoxCollider2D>().size = new Vector2(13.01794f, 10.27758f);

                movementSpeed = .5f;
                anime.SetBool("LongStretch", false);
                anime.SetBool("StretchAttack", false);
                slothNotAttacked = true;
            }
            if (number == 2 && !slothAttacking)
            {
                slothAttacking = true;
                anime.SetBool("LongStretch", true);
                anime.SetBool("StretchAttack", false);

                yield return new WaitForSeconds(2f);
                anime.SetBool("LongStretch", false);
                anime.SetBool("StretchAttack", false);
                slothNotAttacked = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage(30, 15, 35, collision);
    }
}
