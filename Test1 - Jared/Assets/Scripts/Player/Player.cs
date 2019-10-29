
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;
// to close game Application.Quit();
// UnityEditor.EditorApplication.isPlaying = false;


[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    public bool invinc = false;
    public bool facingRight = false;

    Animator anime;

    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6.5f;
    public static GameObject player;
    public GameObject Death;
    public GameObject actualDeath;
    public GameObject deathText;
    public GameObject iceBook;
    public GameObject fireBook;
    public bool fireBookHeld;
    public bool iceBookHeld;
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;
    public GameObject ice1;
    public GameObject ice2;
    public GameObject ice3;
    public GameObject iceText;
    public GameObject fireballText;
    public GameObject healthBar;

    public float moveX;

    float formerPosition = 0;

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    Controller2D controller;

    public Rigidbody2D rb;

    Vector2 directionalInput;

    HealthManager healthManager;

    void Start()
    {
        anime = GetComponent<Animator>();
        fireBookHeld = true;
        Physics2D.IgnoreLayerCollision(8, 9);
        controller = GetComponent<Controller2D>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);

}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10 && !invinc)
        {
            if (collision.gameObject.layer == 10 && collision.gameObject.transform.position.x > player.transform.position.x)
            {
                velocity.x += -100;
            }
            if (collision.gameObject.layer == 10 && collision.gameObject.transform.position.x <= player.transform.position.x)
            {
                velocity.x += 100;
            }
            StartCoroutine(WaitEnemy(.75f));
        }
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        anime.SetFloat("Speed", Math.Abs(h));

        if (Input.GetKeyDown(KeyCode.T))
        {
            //whenever the ice book is held it hides all of the fireball related ui and brings the ice ui to the front
            iceBookHeld = true;
            fireBookHeld = false;
            fireBook.SetActive(false);
            iceBook.SetActive(true);
            ice1.SetActive(true);
            ice2.SetActive(true);
            ice3.SetActive(true);
            iceText.SetActive(true);
            fire1.SetActive(false);
            fire2.SetActive(false);
            fire3.SetActive(false);
            fireballText.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            iceBookHeld = false;
            fireBookHeld = true;
            fireBook.SetActive(true);
            iceBook.SetActive(false);
            ice1.SetActive(false);
            ice2.SetActive(false);
            ice3.SetActive(false);
            iceText.SetActive(false);
            fire1.SetActive(true);
            fire2.SetActive(true);
            fire3.SetActive(true);
            fireballText.SetActive(true);
        }
        
        if (gameObject.transform.position.y <= -100)
        {
            Dead();
        }
        if (gameObject.GetComponent<HealthManager>().health <= 0)
        {
            Dead();
        }

        PlayerMoves();
        
        CalculateVelocity();
        

        controller.Move(velocity * Time.deltaTime, directionalInput);

        if (controller.collisions.above || controller.collisions.below)
        {
            if (controller.collisions.slidingDownMaxSlope)
            {
                velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;
            }
            else
            {
                velocity.y = 0;
            }
        }

    }

    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

    public void OnJumpInputDown()
    {
        
        if (controller.collisions.below)
        {
            if (controller.collisions.slidingDownMaxSlope)
            {
                if (directionalInput.x != -Mathf.Sign(controller.collisions.slopeNormal.x))
                { // not jumping against max slope
                    velocity.y = maxJumpVelocity * controller.collisions.slopeNormal.y;
                    velocity.x = maxJumpVelocity * controller.collisions.slopeNormal.x;
                }
            }
            else
            {
                velocity.y = maxJumpVelocity;
            }
        }
    }


    void CalculateVelocity()
    {
        float targetVelocityX = directionalInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
      

    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10 && !invinc)
        {
            
            StartCoroutine(WaitEnemy(.75f));
        }
        if (collision.gameObject.tag == "SlothBoss" && !invinc)
        {
            StartCoroutine(WaitEnemy(.75f));
        }
    }
    public void OnJumpInputUp()
    {
        if (velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;

        }
    }
    IEnumerator WaitQuit (float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Application.Quit();
    }
    IEnumerator WaitEnemy(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        invinc = false;
    }
    void damage()
    {
        invinc = true;
    }
    public void Dead()
    {
        Death.SetActive(true);
        deathText.SetActive(true);
        actualDeath.SetActive(true);
        fire1.SetActive(false);
        fire2.SetActive(false);
        fire3.SetActive(false);
        ice1.SetActive(false);
        ice2.SetActive(false);
        ice3.SetActive(false);
        healthBar.SetActive(false);
    }



    public void Save()
    {
        string path = "SaveFile/Output.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("TEST");
        writer.Close();
    }
    public void Load()
    {
        string path = "SaveFile/Output.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }

    void PlayerMoves()
    {
        //Player Direction
        player = GameObject.Find("Player");
        if (player.transform.position.x < formerPosition && !facingRight)
        {
            FlipPlayer();
        }
        else if (player.transform.position.x > formerPosition && facingRight)
        {
            FlipPlayer();
        }
        formerPosition = player.transform.position.x;


        //Physics
        void FlipPlayer()
        {
            facingRight = !facingRight;
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }

    }
 }

