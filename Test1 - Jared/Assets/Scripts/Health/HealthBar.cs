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
            healthBar.y = 10f;
            healthBarsBackgroundScale.y = 10f;
            healthBar.x = health * 1.5f;
            healthBarsBackgroundScale.x = healthMax * 1.5f;
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

        if (collision.gameObject.tag == "Enemy" && gameObject.tag == "Player")
        {
            Damage(20);
        }
    }

    IEnumerator WaitHealthBar (float seconds)
    {
        
        yield return new WaitForSeconds(seconds);
        healthBars.SetActive(false);
        overallHealthBar.SetActive(false);
    }
}
