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
             Save();
        }
    }


    public void Save()
    {
        string spellEquiped;
        string path = "Output.txt";
        if (player.iceBookHeld && !player.fireBookHeld)
        {
            spellEquiped = "i";
        }
        else if (player.fireBookHeld && !player.iceBookHeld)
        {
            spellEquiped = "f";
        }
        else
        {
            spellEquiped = "n";
        }
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path);
        string Save = 2 + spellEquiped;
        writer.WriteLine(Save);
        writer.Close();
        Debug.Log("Saved");
    }
}
