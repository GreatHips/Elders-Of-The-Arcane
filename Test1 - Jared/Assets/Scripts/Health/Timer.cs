using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeSinceAttacked;
    public GameObject overallHealthBar;
    public GameObject healthBars;
    public GameObject healthBarsBackground;
    void timeComponents()
    {
        if (timeSinceAttacked <= -5 && gameObject.tag == "Enemy" || gameObject.tag == "Boss")
        {
            overallHealthBar.SetActive(false);
            healthBars.SetActive(false);
            healthBarsBackground.SetActive(false);
        }
        else if (timeSinceAttacked > -10 && gameObject.tag == "Enemy" || gameObject.tag == "Boss")
        {
            overallHealthBar.SetActive(true);
            healthBars.SetActive(true);
            healthBarsBackground.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullets" && gameObject.tag == "Boss" || gameObject.tag == "Enemy")
        {
            timeSinceAttacked = 0;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        timeComponents();
    }
}
