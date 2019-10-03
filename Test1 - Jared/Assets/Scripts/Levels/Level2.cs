using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level2 : MonoBehaviour
{
    public GameObject blackScreen;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
