using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    Vector3 localscale;
    public GameObject health;
    public bool activated = false;
    void Start()
    {
        localscale = transform.localScale;
        
    }

    void Update()
    {
        localscale.x = EnemyAI.enemyHealth / 20;
        transform.localScale = localscale;
    }
}
