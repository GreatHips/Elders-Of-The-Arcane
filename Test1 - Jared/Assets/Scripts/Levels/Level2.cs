using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class Level2 : MonoBehaviour
{
    Player player;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            SceneManager.LoadScene("Level2");
            Player.SavePlayer();
        }
    }
    }
