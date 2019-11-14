using System;
using System.IO;
using System.Text;
using UnityEngine;


public class SaveSystem
{
    Player player;
   
    public static void SavePlayer()
    {
    string path = "SaveFile/Save.txt";
        
        // This text is added only once to the file.
        
            string createText = "text" +Environment.NewLine;
            File.WriteAllText(path, createText);
    }
    public void LoadPlayer()
    {
        /* Open the file to read from.
        string readText = File.ReadAllText(path);
        Console.WriteLine(readText); */
    }
}
