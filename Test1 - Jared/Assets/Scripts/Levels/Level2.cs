using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


public class Level2 : Player
{
    string spellEquiped;

    private void Start()
    {
        var player = GameObject.Find("Player");
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Level2");
            if (iceBookHeld == true)
            {
                spellEquiped = "i";
            }
            else if (fireBookHeld == true)
            {
                spellEquiped = "f";
            }
            else
            {
                spellEquiped = "n";
            }
            Save(2, spellEquiped);
        }
    }
}
