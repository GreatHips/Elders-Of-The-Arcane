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

            yield return new WaitForSeconds(UnityEngine.Random.Range(1, 3));
            var number = UnityEngine.Random.Range(1, 5);
            Debug.Log(number);

            slothAttacked = true;
            if (number == 1)
            {
                anime.SetBool("HeadAttack", true);
                
            }
            if (number == 2)
            {
                anime.SetBool("HeadAttack", true);

            }
            if (number == 3)
            {
                anime.SetBool("HeadAttack", true);

            }
            if (number == 4)
            {
                anime.SetBool("HeadAttack", true);

            }

            if (slothAttacked == true)
            {
                yield return new WaitForSeconds(10);
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
