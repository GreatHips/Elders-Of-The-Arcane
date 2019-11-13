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



public class Player : MonoBehaviour
{
    public bool facingRight = false;

    Animator anime;

    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    public float moveSpeed = 6.5f;
    public static GameObject player;
    public GameObject Death;
    public GameObject actualDeath;
    public GameObject deathText;
    public GameObject iceBook;
    public GameObject fireBook;
    public GameObject speedBook;
    public bool fireBookHeld;
    public bool iceBookHeld;
    public bool speedBookHeld;
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;
    public GameObject ice1;
    public GameObject ice2;
    public GameObject ice3;
    public GameObject speed1;
    public GameObject speed2;
    public GameObject speed3;
    public GameObject speedText;
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

    public Scene currentScene;
    public Rigidbody2D rb;
    string sceneName;
    public int sceneInt;

    [HideInInspector]
    public int bookHeldInt = 1;
    Vector2 directionalInput;

    HealthManager healthManager;

    void Start()
    {
         currentScene = SceneManager.GetActiveScene();

        sceneName = currentScene.name;
        if (sceneName == "Level1")
        {
            sceneInt = 1;
        }

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
        
        if (collision.gameObject.layer == 10)
        {
            if (collision.gameObject.layer == 10 && collision.gameObject.transform.position.x > player.transform.position.x)
            {
                velocity.x += -40;
            }
            if (collision.gameObject.layer == 10 && collision.gameObject.transform.position.x <= player.transform.position.x)
            {
                velocity.x += 40;
            }
            StartCoroutine(WaitEnemy(.75f));
        }
    }
    void findParameters()
    {

    }
    void setIce(bool active)
    {
        iceBookHeld = active;
        iceBook.SetActive(active);
        ice1.SetActive(active);
        ice2.SetActive(active);
        ice3.SetActive(active);
        iceText.SetActive(active);
    }
    void setFire(bool active)
    {
        fireBookHeld = active;
        fireBook.SetActive(active);
        fire1.SetActive(active);
        fire2.SetActive(active);
        fire3.SetActive(active);
        fireballText.SetActive(active);
    }
    void setSpeed(bool active)
    {
        speedBookHeld = active;
        speedBook.SetActive(active);
        speed1.SetActive(active);
        speed2.SetActive(active);
        speed3.SetActive(active);
        speedText.SetActive(active);
    }
    void checkBookHeld()
    {
        if (fireBookHeld && !iceBookHeld && !speedBookHeld)
        {
            bookHeldInt = 1;
        }
        else if (!fireBookHeld && iceBookHeld && !speedBookHeld)
        {
            bookHeldInt = 2;
        }
         else if (!fireBookHeld && !iceBookHeld && speedBookHeld)
        {
            bookHeldInt = 3;
        }

        if (bookHeldInt == 1)
        {
            setFire(true);
            setIce(false);
            setSpeed(true);
        }
        else if (bookHeldInt == 2)
        {
            setFire(false);
            setIce(true);
            setSpeed(false);
        }
        else if (bookHeldInt == 3)
        {
            setFire(false);
            setIce(false);
            setSpeed(true);
        }
    }
    void Update()
    {
        checkBookHeld();

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        anime.SetFloat("Speed", Math.Abs(h));

       

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


    public void CalculateVelocity()
    {
        float targetVelocityX = directionalInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;


    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {

            StartCoroutine(WaitEnemy(.75f));
        }
        if (collision.gameObject.tag == "SlothBoss")
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
    IEnumerator WaitQuit(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Application.Quit();
    }
    IEnumerator WaitEnemy(float seconds)
    {
        yield return new WaitForSeconds(seconds);
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
        //no
    }
}