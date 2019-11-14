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
    [HideInInspector]
    public GameObject fire1;
    [HideInInspector]
    public GameObject fire2;
    [HideInInspector]
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
    public static int sceneInt;

    public int bookHeldInt = 0;
    Vector2 directionalInput;

    HealthManager healthManager;

    void checkParameters() {
        fire1 = GameObject.Find("Fire1");
        fire2 = GameObject.Find("Fire2");
        fire3 = GameObject.Find("Fire3");
    }
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
    void checkBookHeld()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            bookHeldInt += 1;
            if (bookHeldInt >= 4)
            {
                bookHeldInt = 1;
            }
        }
        if (bookHeldInt == 1)
        {
            fireBookHeld = true;
            fireBook.SetActive(true);
            fire1.SetActive(true);
            fire2.SetActive(true);
            fire3.SetActive(true);
            fireballText.SetActive(true);
            fireBookHeld = true;
            iceBook.SetActive(false);
            ice1.SetActive(false);
            ice2.SetActive(false);
            ice3.SetActive(false);
            iceText.SetActive(false);
            speedBookHeld = false;
            speedBook.SetActive(false);
            speed1.SetActive(false);
            speed2.SetActive(false);
            speed3.SetActive(false);
            speedText.SetActive(false);
        }
        if (bookHeldInt == 2)
        {
            fireBookHeld = false;
            fireBook.SetActive(false);
            fire1.SetActive(false);
            fire2.SetActive(false);
            fire3.SetActive(false);
            fireballText.SetActive(false);
            fireBookHeld = true;
            iceBook.SetActive(true);
            ice1.SetActive(true);
            ice2.SetActive(true);
            ice3.SetActive(true);
            iceText.SetActive(true);
            speedBookHeld = false;
            speedBook.SetActive(false);
            speed1.SetActive(false);
            speed2.SetActive(false);
            speed3.SetActive(false);
            speedText.SetActive(false);
        }
        if (bookHeldInt == 3)
        {
            fireBookHeld = false;
            fireBook.SetActive(false);
            fire1.SetActive(false);
            fire2.SetActive(false);
            fire3.SetActive(false);
            fireballText.SetActive(false);
            fireBookHeld = false;
            iceBook.SetActive(false);
            ice1.SetActive(false);
            ice2.SetActive(false);
            ice3.SetActive(false);
            iceText.SetActive(false);
            speedBookHeld = true;
            speedBook.SetActive(true);
            speed1.SetActive(true);
            speed2.SetActive(true);
            speed3.SetActive(true);
            speedText.SetActive(true);
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
    public static void SavePlayer()
    {
        string path = "SaveFile/Save.txt";

        // This text is added only once to the file.

        string createText = sceneInt + Environment.NewLine;
        File.WriteAllText(path, createText);
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