using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : HealthManager
{
    public Vector3 healthBar;
    public GameObject overallHealthBar;
    public GameObject healthBars;
    public GameObject healthBarsBackground;
    public Vector3 healthBarsBackgroundScale;
    void Start()
    {
        healthBar = healthBars.transform.localScale;
        healthBarsBackgroundScale = healthBarsBackground.transform.localScale;
    }

    public void Update()
    {
        if (gameObject.tag == "Enemy")
        {
            healthBar.y = 20f;
            healthBarsBackgroundScale.y = 10f;
            healthBar.x = health * 3f;
            healthBarsBackgroundScale.x = healthMax * 3f;
            healthBars.transform.localScale = healthBar;
            healthBarsBackground.transform.localScale = healthBarsBackgroundScale;
        }
        if (gameObject.tag == "Boss")
        {
            healthBar.y = 20f;
            healthBarsBackgroundScale.y = 20f;
            healthBar.x = health * .25f;
            healthBarsBackgroundScale.x = healthMax * .25f;
            healthBars.transform.localScale = healthBar;
            healthBarsBackground.transform.localScale = healthBarsBackgroundScale;
        }
        if (gameObject.tag == "Player")
        {
            healthBar.y = .5f;
            healthBarsBackgroundScale.y = .25f;
            healthBar.x = health / 15;
            healthBarsBackgroundScale.x = healthMax / 15;
           
            healthBars.transform.localScale = healthBar;
            
            healthBarsBackground.transform.localScale = healthBarsBackgroundScale;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullets" && gameObject.tag == "Enemy")
        {
            overallHealthBar.SetActive(true);
            healthBars.SetActive(true);
            StartCoroutine(WaitHealthBar(5f));
            Damage(50);
        }

        if (collision.gameObject.tag == "Bullets" && gameObject.tag == "Boss")
        {
            overallHealthBar.SetActive(true);
            healthBars.SetActive(true);
            Damage(25);
        }

        if (collision.gameObject.tag == "Enemy" && gameObject.tag == "Player")
        {
            Damage(20);
        }
        if (collision.gameObject.tag == "Boss" && gameObject.tag == "Player")
        {
            Damage(34);
        }
    }

    IEnumerator WaitHealthBar (float seconds)
    {
        
        yield return new WaitForSeconds(seconds);
        healthBars.SetActive(false);
        overallHealthBar.SetActive(false);
    }
}
