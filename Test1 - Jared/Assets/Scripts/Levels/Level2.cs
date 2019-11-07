using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


public class Level2 : MonoBehaviour
{
    string spellEquiped;
    Player player;
    void Start()
    {
        var player = GameObject.Find("Player");
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Level2");
            if (player.iceBookHeld == true)
            {
                spellEquiped = "i";
            }
            else if (player.fireBookHeld == true)
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
    
    public void Save(int level, string Book)
    {
        string path = "SaveFile/Output.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);
        string Save = level + Book;
        writer.WriteLine(Save);
        writer.Close();
    }
    
}
