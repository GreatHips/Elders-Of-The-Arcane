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


    new void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        dist = Math.Abs(Vector3.Distance(target.position, transform.position));
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        // Boss Parameters
        if (gameObject.tag == "SlothBoss" && gameObject.GetComponent<HealthManager>().health < gameObject.GetComponent<HealthManager>().healthMax)
        {
            anime.SetBool("Awake", true);
            if (movement && inDist)
            {

                transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);

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
            var number = UnityEngine.Random.Range(1, 3);
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
                headClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(-250, 0));

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

                headClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(500, 0));
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
                //offset 0.1 x = 24.61, y = 10.63454
                yield return new WaitForSeconds(.5f);
                sloth.GetComponent<BoxCollider2D>().size = new Vector2(24.61f, 10.63454f);
                sloth.GetComponent<BoxCollider2D>().offset = new Vector2(0.1f, -4.68273f);
                yield return new WaitForSeconds(.5f);

                sloth.GetComponent<BoxCollider2D>().size = new Vector2(12.58447f, 10.74055f);
                sloth.GetComponent<BoxCollider2D>().offset = new Vector2(3.556674f, -4.68273f);
                yield return new WaitForSeconds(.5f);
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
}
