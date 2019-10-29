using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeDemon : EnemyAI
{

    // Update is called once per frame
    void Update()
    {
        if (movement && inDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
            anime.SetBool("Chase", true);

        }
        else if (!inDist)
        {
            anime.SetBool("Chase", false);
        }

        if ((target.position.x < transform.position.x) && facingRight == true && inDist)
        {
            transform.Rotate(Vector3.up * 180);
            facingRight = false;
        }
        else if ((target.position.x > transform.position.x) && facingRight == false && inDist)
        {
            transform.Rotate(Vector3.up * 180);
            facingRight = true;
        }
    }
}
