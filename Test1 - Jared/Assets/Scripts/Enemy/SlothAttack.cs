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
    public GameObject headPrefab;
    private GameObject player;

    
    new void Start()
    {
        anime = GetComponent<Animator>();
        player = GameObject.Find("Player");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
            anime.SetBool("Awake", true);
            if (movement && inDist)
            {

                transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
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
            var number = UnityEngine.Random.Range(2, 2);
            Debug.Log(number);
            // box collider normal size x = 12.58447 y = 10.74055

            if (number == 1 && !slothAttacking)
            {
                movementSpeed = 0;
                //enables anim
                anime.SetBool("HeadAttack", true);
                //wait .5 seconds to start everything
                yield return new WaitForSeconds(.5f);
                var player = GameObject.Find("Player");
                var sloth = GameObject.Find("SlothBoss");
                //x = .54, y = -7.22, instantiate head here!!
                var head = headPrefab;
                //spawn a clone of the head

                var headClone = (GameObject)Instantiate(head, sloth.transform);
                Physics2D.IgnoreLayerCollision(13, 11);

                headClone.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionX;

                //addforce to the clone so it goes left
                if (!facingRight)
                {
                    headClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(250, 0));
                }
                else if (facingRight)
                {
                    headClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(-250, 0));
                }
                //add a box collider to the cloned object
                headClone.AddComponent<BoxCollider2D>();

                //sets the box collider to a certain size to match the image
                headClone.GetComponent<BoxCollider2D>().size = new Vector2(2.5f, 3.8f);

                //check for the sloths attacking


                //wait a second
                yield return new WaitForSeconds(1);

                //turns off the clones box collider
                headClone.GetComponent<BoxCollider2D>().enabled = false;

                //sends the cloned object sending right
                if (!facingRight)
                {
                    headClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500, 0));
                } else if (facingRight)
                {
                    headClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(500, 0));
                }
                    yield return new WaitForSeconds(.6f);
                slothAttacked = true;

                if (anime.GetCurrentAnimatorStateInfo(0).IsName("Sloth_shoot"))
                {
                    anime.SetBool("HeadAttack", false);
                    anime.SetBool("StretchAttack", false);
                    anime.SetBool("Awake", true);
                    yield return new WaitForSeconds(.6f);
                    slothAttacking = false;
                    movementSpeed = .75f;
                    Destroy(headClone);
                }
            }
            if (number == 2 && !slothAttacking)
            {
                var sloth = GameObject.Find("SlothBoss");

                slothAttacking = true;
                movementSpeed = 0;
                anime.SetBool("StretchAttack", true);
                //left norm = x = 12.66573 y = 10.2775
                //offset left norm = x = -3.645622 y = -4.504251

                //right norm = x = 12.58447f  y = 10.74055f
                //offset right norm = x = 3.556674f  y = -4.68273f

                //stretch right norm = x = 24.49597 y = 10.27758
                //stretch right offset = x = 0.1113005 y = -4.504251
                yield return new WaitForSeconds(.5f);
                if (!facingRight)
                {
                    sloth.GetComponent<BoxCollider2D>().size = new Vector2(24.61f, 10.63454f);
                    sloth.GetComponent<BoxCollider2D>().offset = new Vector2(0.1f, -4.68273f);
                } else if (facingRight)
                {
                    sloth.GetComponent<BoxCollider2D>().size = new Vector2(24.49597f, 10.27758f);
                    sloth.GetComponent<BoxCollider2D>().offset = new Vector2(0.1113005f ,4.504251f);
                }
                sloth.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                yield return new WaitForSeconds(.6f);

                if (!facingRight)
                {
                    sloth.GetComponent<BoxCollider2D>().size = new Vector2(12.58447f, 10.74055f);
                    sloth.GetComponent<BoxCollider2D>().offset = new Vector2(3.556674f, -4.68273f);
                } else if (facingRight)
                {
                    sloth.GetComponent<BoxCollider2D>().size = new Vector2(12.66573f, 10.2775f);
                    sloth.GetComponent<BoxCollider2D>().offset = new Vector2(-3.645622f, -4.504251f);
                }
                    yield return new WaitForSeconds(.5f);
                sloth.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezeAll;
                sloth.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                anime.SetBool("HeadAttack", false);
                anime.SetBool("StretchAttack", false);
                anime.SetBool("Awake", true);
                slothAttacking = false;
                slothAttacked = true;
                movementSpeed = .75f;


            }
            if (number == 3 && !slothAttacking)
            {
                slothAttacking = true;
                anime.SetBool("HeadAttack", true);
                slothAttacked = true;
            }
            if (number == 4 && !slothAttacking)
            {
                slothAttacking = true;
                anime.SetBool("HeadAttack", true);
                slothAttacked = true;
            }

            if (slothAttacked == true)
            {
                slothAttacking = false;
                yield return new WaitForSeconds(2);
                anime.SetBool("HeadAttack", false);
                anime.SetBool("Awake", true);
                slothNotAttacked = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<HealthManager>().Damage(35);
        }
        if (collision.gameObject.tag == "Bullets")
        {
            GetComponent<HealthManager>().Damage(30);
        }
    }
}
