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

    Animator anime;

    HealthManager healthManager;
    public void Start()
    {
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

        if (gameObject.tag == "SlothBoss" && gameObject.GetComponent<HealthManager>().health < gameObject.GetComponent<HealthManager>().healthMax)
        {

            if (movement && inDist)
            { 
                transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);

            }

            if (){
                anime.SetBool("HeadAttack", true);
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

    IEnumerator WaitJump()
    {
        isJumping = true;
        if (isJumping)
        {
            this.GetComponent<Animation>().enabled = true;
        } else if (!isJumping)
        {
            this.GetComponent<Animation>().enabled = false; 
        }
        yield return new WaitForSeconds(2);
        
        isJumping = false;
    }
}
