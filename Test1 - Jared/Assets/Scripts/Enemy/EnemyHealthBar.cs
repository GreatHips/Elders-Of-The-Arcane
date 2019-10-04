using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    Vector3 localscale;
    BaseEnemy baseEnemy;

    public void Start()
    {
        localscale = transform.localScale;
        
    }

    public void Update()
    {
        localscale.x = baseEnemy._currentHealth;
        
        transform.localScale = localscale;
    }
}
