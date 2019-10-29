using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject scoreObject;
    public int newScore;
    public int score = 0;

    // Update is called once per frame
    void Update()
    {
        /*
        if (gameObject.GetComponent<HealthManager>().health <= 0)
        {
            score += 10;
            newScore = score;
            scoreObject.GetComponent<Text>().text = "Score: " + newScore;
        }
        */
    }
}
