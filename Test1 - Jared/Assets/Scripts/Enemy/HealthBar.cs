using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Vector3 healthBar;
    public GameObject healthBars;

    HealthManager healthManager;

    void Start()
    {
        healthBar = transform.localScale;
        healthBars.SetActive(false);
    }

    public void Update()
    {
        healthBar.x = healthManager.GetHealth(); 
        transform.localScale = healthBar;
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullets")
        {
            healthBars.SetActive(true);
            StartCoroutine(WaitHealthBar(5f));
            HealthManager.UpdateHealth();
        }
    }

    IEnumerator WaitHealthBar (float seconds)
    {
        
        yield return new WaitForSeconds(seconds);
        healthBars.SetActive(false);
    }
}
