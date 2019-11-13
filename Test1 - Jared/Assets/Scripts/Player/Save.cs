using System;
using System.IO;
using System.Text;
using UnityEngine;

public static class SaveSystem
{
    public static void SavePlayer()
    {
        string path = "SaveFile/Save.txt";

        // This text is added only once to the file.
            string createText = "OVERWRITE?" + Environment.NewLine;
            File.WriteAllText(path, createText);
    }
    public static void LoadPlayer()
    {
        /* Open the file to read from.
        string readText = File.ReadAllText(path);
        Console.WriteLine(readText); */
    }
}
