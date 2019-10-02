using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    public GameObject bullet;
    public Player player;
    GameObject b;

    public void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 11);
    }
     private void Update()
    {
        int varFacingRight = 1;
            
            if (player.facingRight == false) {
            varFacingRight = -1;
            
        }      
            if (Input.GetButtonDown("Fire1"))

            {

                GameObject b = (GameObject)(Instantiate(bullet, transform.position + transform.right * varFacingRight* -1.5f, Quaternion.identity));
                
                b.GetComponent<Rigidbody2D>().AddForce(transform.right *varFacingRight * -1000);

            if (player.facingRight)
            {
                b.transform.Rotate(0, 0, -90f, Space.Self);
            } else if (player.facingRight == false)
            {
                b.transform.Rotate(0, 0, 90f, Space.Self);
                
            }

            Destroy(b, 2f);
            }

    }
    
}
