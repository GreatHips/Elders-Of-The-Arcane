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
        // sets healthBar vector3 to the scale of the healthbar
        healthBar = healthBars.transform.localScale;

        // sets the background vector3 to the scale of the background
        healthBarsBackgroundScale = healthBarsBackground.transform.localScale;

    }

    public void Update()
    {

        // if the tag is an enemy
        if (gameObject.tag == "Enemy")
        {
            healthBar.y = 20f;
            healthBarsBackgroundScale.y = 10f;
            healthBar.x = health * 3f;
            healthBarsBackgroundScale.x = healthMax * 3f;
            healthBars.transform.localScale = healthBar;
            healthBarsBackground.transform.localScale = healthBarsBackgroundScale;
        }
        //if the tag is a boss
        else if (gameObject.tag == "Boss")
        {
            healthBar.y = 20f;
            healthBarsBackgroundScale.y = 20f;
            healthBar.x = health * .25f;
            healthBarsBackgroundScale.x = healthMax * .25f;
            healthBars.transform.localScale = healthBar;
            healthBarsBackground.transform.localScale = healthBarsBackgroundScale;
        }
        //if its the player
        else if (gameObject.tag == "Player")
        {
            healthBar.y = .5f;
            healthBarsBackgroundScale.y = .25f;
            healthBar.x = health / 15;
            healthBarsBackgroundScale.x = healthMax / 15;

            healthBars.transform.localScale = healthBar;

            healthBarsBackground.transform.localScale = healthBarsBackgroundScale;
        }
    }
}
