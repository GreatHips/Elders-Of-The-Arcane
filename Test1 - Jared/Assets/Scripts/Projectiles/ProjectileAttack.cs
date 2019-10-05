using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    public GameObject bullet;
    public Player player;
    GameObject b;
    public bool canAttack = true;
    public int chargeAmounts = Mathf.Max(3);
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;

    public AudioClip fireballSound;

    public AudioSource fireballSource;


    public void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 11);
        
        
       
    }
     private void Update()
    {
       CheckCharges();
        int varFacingRight = 1;
            
            if (player.facingRight == false) {
            varFacingRight = -1;
            
            }
        if (canAttack && chargeAmounts >= 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                chargeAmounts -= 1;

                StartCoroutine(Recharge());


                StartCoroutine(AttackWait(.25f));

                GameObject b = (GameObject)(Instantiate(bullet, transform.position + transform.right * varFacingRight * -2f, Quaternion.identity));
                b.GetComponent<Rigidbody2D>().AddForce(transform.right * varFacingRight * -1000);
                if (varFacingRight == 1)
                {
                    b.transform.Rotate(0, 0, -90f);
                }
                else if (varFacingRight == -1)
                {
                    b.transform.Rotate(0, 0, 90f);
                }
                Destroy(b, 2f);
            }
        }
    }

    void CheckCharges()
    {
        if (chargeAmounts == 0)
        {
            fire1.SetActive(false);
            fire2.SetActive(false);
            fire3.SetActive(false);
            canAttack = false;
        }
        else if(chargeAmounts == 1)
        {
            fire1.SetActive(true);
            fire2.SetActive(false);
            fire3.SetActive(false);
            canAttack = true;
        } else if(chargeAmounts == 2)
        {
            fire1.SetActive(true);
            fire2.SetActive(true);
            fire3.SetActive(false);
            canAttack = true;
        } else if (chargeAmounts == 3)
        {
            fire1.SetActive(true);
            fire2.SetActive(true);
            fire3.SetActive(true);
            canAttack = true;
        }
        if (chargeAmounts >= 4)
        {
            chargeAmounts = 3;
        }


    }

    IEnumerator AttackWait(float seconds)
    {
        canAttack = false;
        fireballSource.PlayOneShot(fireballSound);
        yield return new WaitForSeconds(seconds);
        
        canAttack = true;
    }

    IEnumerator Recharge ()
    {

        if (chargeAmounts == 0)
        {
            yield return new WaitForSeconds(2f);
            chargeAmounts += 1;
           
        }
        if (chargeAmounts == 1)
        {
            yield return new WaitForSeconds(2f);
            
            chargeAmounts += 1;
            
        } 
        if (chargeAmounts == 2)
        {
            yield return new WaitForSeconds(2f);
            chargeAmounts += 1;
            
        }
        
     }
    
}
