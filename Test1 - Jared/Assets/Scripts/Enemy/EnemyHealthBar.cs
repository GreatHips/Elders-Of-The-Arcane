using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    Vector3 localscale;
    public GameObject health;
    void Start()
    {
        localscale = transform.localScale;
        
    }

    void Update()
    {
        localscale.x =  EnemyHealthManager.InternalHealth / 25;
        transform.localScale = localscale;
    }
}
