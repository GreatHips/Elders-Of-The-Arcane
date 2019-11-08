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
        Move();
    }

    public void Move()
    {
        
    }
}
