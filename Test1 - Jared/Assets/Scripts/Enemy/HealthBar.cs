using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Vector3 healthBar;
    public GameObject overallHealthBar;
    public GameObject healthBars;

    HealthManager healthManager;

    void Start()
    {
        healthBar = transform.localScale;
        
    }

    public void Update()
    {
        healthBar.x = healthManager.health; 
        healthBars.transform.localScale = healthBar;
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullets")
        {
            overallHealthBar.SetActive(true);
            healthBars.SetActive(true);
            StartCoroutine(WaitHealthBar(5f));
            healthManager.Damage(50);
        }
    }

    IEnumerator WaitHealthBar (float seconds)
    {
        
        yield return new WaitForSeconds(seconds);
        healthBars.SetActive(false);
        overallHealthBar.SetActive(false);
    }
}
