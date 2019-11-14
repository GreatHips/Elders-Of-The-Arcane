using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMen : MonoBehaviour
{
    Player player;
    public void NewGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadGame()
    {
       
        player.Load();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
