using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class Player2 : MonoBehaviour
{
    public bool facingRight = false;

    Animator anime;


    [SerializeField] private float maxJumpHeight = 4;
    [SerializeField] private float minJumpHeight = 1;
    [SerializeField] private float timeToJumpApex = .4f;
    [SerializeField] private float accelerationTimeAirborne = .2f;
    [SerializeField] private float accelerationTimeGrounded = .1f;
    [SerializeField] private float moveSpeed = 6.5f;
    private Vector2 direction;
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

    public Scene currentScene;
    public Rigidbody2D rb;
    string sceneName;
    public int sceneInt;

    Vector2 directionalInput;

    HealthManager healthManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
    }

    public void Move()
    {
        transform.Translate(direction*Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void GetInput()
    {
        direction = Vector2.zero;
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction += Vector2.right;
        }
    }
    
}
