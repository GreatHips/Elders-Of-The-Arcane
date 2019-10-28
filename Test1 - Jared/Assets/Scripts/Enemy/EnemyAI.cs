using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(EnemyController))]
public class EnemyAI : MonoBehaviour
{
    private Transform target;
    public static bool movement = true;
    public float movementSpeed = 2.0f;
    public float stoppingDistance = 250f;
    private bool facingRight = true;
    private bool canJump = true;
    private Rigidbody2D myRigidBody;
    public bool isJumping = false;
    public float dist;
    public bool inDist;
    public bool slothNotAttacked = true;
    public bool slothAttacked = false;
    public bool slothAttacking;

    Animator anime;

    HealthManager healthManager;
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

        if (gameObject.tag == "Slime")
        {
            
            if (movement && inDist)
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
                var player = GameObject.Find("Player");
                player.GetComponent<Rigidbody2D>().velocity *= 0;

                StartCoroutine(SlothBossAttack());
            }
          
        }

        if (gameObject.tag == "Boar")
        { 

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

        if (gameObject.tag == "eyeDemon")
        {
         
            
            if (movement && inDist)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
                anime.SetBool("Chase", true);

            } else if (!inDist)
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
    }
    IEnumerator SlothBossAttack()
    {
        if (slothNotAttacked)
        {
            slothNotAttacked = false;

            //SLOTH NEEDS TO BE DONE COMPLETELY
            yield return new WaitForSeconds(UnityEngine.Random.Range(1, 3));
            var number = UnityEngine.Random.Range(1, 1);
            Debug.Log(number);
            // box collider normal size x = 12.58447 y = 10.74055

            if (number == 1 && !slothAttacking)
            {
                //enables anim
                anime.SetBool("HeadAttack", true);
                //wait .5 seconds to start everything
                yield return new WaitForSeconds(.5f);
                var sloth = GameObject.Find("SlothBoss");
                var head = GameObject.Find("SlothHead");

                //spawn a clone of the head
                var headClone = Instantiate(head, sloth.transform, false);
                headClone.GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezePositionX;
               
                //addforce to the clone so it goes left
                headClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(-250, 0));

                //add a box collider to the cloned object
                headClone.AddComponent<BoxCollider2D>();

                //sets the box collider to a certain size to match the image
                headClone.GetComponent<BoxCollider2D>().size = new Vector2(2.5f, 3.8f);
                

                //remove the original head from the scene
                head.SetActive(false);

                //check for the sloths attacking
                    slothAttacking = true;

                //wait a second
                    yield return new WaitForSeconds(1);

                //turns off the clones box collider
                headClone.GetComponent<BoxCollider2D>().enabled = false;

                //sends the cloned object sending right
                headClone.GetComponent<Rigidbody2D>().AddForce(new Vector2(500, 0));

                yield return new WaitForSeconds(1);

                //sets the head active again
                head.SetActive(true);

                //destroys the clone immediately
                    Destroy(headClone);

                    //checks to be done at the end
                    slothAttacked = true;
                    anime.SetBool("HeadAttack", false);
                    anime.SetBool("Awake", true);
            }
            if (number == 2 && !slothAttacking)
            {
                slothAttacking = true;
                anime.SetBool("HeadAttack", true);
                slothAttacked = true;
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
    IEnumerator WaitJump()
    {
        isJumping = true;
        if (isJumping)
        {
            GetComponent<Animation>().enabled = true;
        } else if (!isJumping)
        {
           GetComponent<Animation>().enabled = false; 
        }
        yield return new WaitForSeconds(2);
        
        isJumping = false;
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

}
