using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(EnemyController))]
public class EnemyAI : MonoBehaviour
{
    private Transform target;
    public static bool movement = true;
    public float movementSpeed = 2.0f;
    public float stoppingDistance = 250;
    private bool facingRight = true;
    private bool canJump = true;
    private Rigidbody2D myRigidBody;
    public bool isJumping = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       
        float dist = Math.Abs(Vector3.Distance(target.position, transform.position));
        if (movement && dist < stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);

        }
        
        if ((target.position.y > this.transform.position.y)&&myRigidBody.velocity.y==0&& (Math.Abs(target.position.x - this.transform.position.x)<20) && dist < stoppingDistance && !isJumping){
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, 7.25f, 0); ;
            StartCoroutine(WaitJump());
        }
        if ((target.position.x < this.transform.position.x)&&facingRight==true && dist < stoppingDistance)
        {
            transform.Rotate(Vector3.up * 180);
            facingRight = false;
        }else if((target.position.x > this.transform.position.x)&& facingRight == false && dist < stoppingDistance)
        {
            transform.Rotate(Vector3.up * 180);
            facingRight = true;
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
