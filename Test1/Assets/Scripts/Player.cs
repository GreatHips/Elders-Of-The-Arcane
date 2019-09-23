using UnityEngine;
using System.Collections;
// to close game Application.Quit();
// UnityEditor.EditorApplication.isPlaying = false;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    public bool invinc = false;
    public bool facingRight = false;

    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;
    public int internalHealth = globalHealth;
    public static int globalHealth = Mathf.Max(3);
    public static GameObject player;
    public GameObject healthBar1;
    public GameObject healthBar2;
    public GameObject healthBar3;
    public GameObject blackOverView;
    public GameObject actualDeath;
    public GameObject deathText;
    

    public float moveX;

    float formerPosition = 0;

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    Controller2D controller;

    Vector2 directionalInput;
    bool wallSliding;
    int wallDirX;


    void Start()
    {
        controller = GetComponent<Controller2D>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !invinc)
        {
            damage();
            StartCoroutine(Wait(.75f));
        }
    }
    void Update()
    {
        


        player = GameObject.Find("Player");
        if (player.transform.position.y <= -100)
        {
            Player.globalHealth = 0;
        }

        PlayerMoves();
        if (globalHealth == 3)
        {
            healthBar3.SetActive(true);
            healthBar2.SetActive(true);
            healthBar1.SetActive(true);
        }
        else if (globalHealth == 2)
        {
            healthBar3.SetActive(false);
            healthBar2.SetActive(true);
            healthBar1.SetActive(true);
        }
        else if (globalHealth == 1)
        {
            healthBar3.SetActive(false);
            healthBar2.SetActive(false);
            healthBar1.SetActive(true);
        }
        else
        {
            blackOverView.SetActive(true);
            actualDeath.SetActive(true);
            deathText.SetActive(true);
            deathText.SetActive(true);
            healthBar3.SetActive(false);
            healthBar2.SetActive(false);
            healthBar1.SetActive(false);
        }
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
    public void OnJumpInputUp()
    {
        if (velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;

        }
    }
    public void OnShiftDown()
    {
        moveSpeed = 80;
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        invinc = false;
        EnemyAI.movement = true;
    }
    void damage()
    {
        EnemyAI.movement = false;
        velocity.x *= -5f;
        globalHealth -= 1;
        invinc = true;
        if(velocity.x == 0 && facingRight)
        {
            
        }

    }


    public void OnShiftUp()
    {
        moveSpeed = 6;
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
