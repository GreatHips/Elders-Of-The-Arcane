using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    public GameObject fireball;
    public GameObject ice;
    public Player player;
    GameObject b;
    public bool canAttack = true;
    public int chargeAmounts = Mathf.Max(3);
    public GameObject fire1;
    public GameObject fire2;
    public GameObject fire3;

    public AudioClip fireballSound;
    public AudioClip iceSound;

    public AudioSource iceSource;
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
        if (canAttack = true && chargeAmounts >= 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                chargeAmounts -= 1;

                StartCoroutine(Recharge());
                if (player.fireBookHeld == true)
                {
                    GameObject bfire = (GameObject)(Instantiate(fireball, transform.position + transform.right * varFacingRight * -2f, Quaternion.identity));
                    bfire.GetComponent<Rigidbody2D>().AddForce(transform.right * varFacingRight * -1000);

                    StartCoroutine(AttackWaitFireball(.75f));
                    if (varFacingRight == 1)
                    {
                        bfire.transform.Rotate(0, 0, -90f);
                    }
                    else if (varFacingRight == -1)
                    {
                        bfire.transform.Rotate(0, 0, 90f);
                    }
                    Destroy(bfire, 2f);
                }
                else if (player.iceBookHeld == true)
                {
                    GameObject bice = (GameObject)(Instantiate(ice, transform.position + transform.right * varFacingRight * -2f, Quaternion.identity));
                    bice.GetComponent<Rigidbody2D>().AddForce(transform.right * varFacingRight * -1000);

                    StartCoroutine(AttackWaitIce(.75f));
                    if (varFacingRight == 1)
                    {
                        bice.transform.Rotate(0, 0, -90f);
                    }
                    else if (varFacingRight == -1)
                    {
                        bice.transform.Rotate(0, 0, 90f);
                    }
                    Destroy(bice, 2f);
                }
            }
        }
    }

    void CheckCharges()
    {
        if (chargeAmounts == 0 && player.fireBookHeld)
        {
            fire1.SetActive(false);
            fire2.SetActive(false);
            fire3.SetActive(false);
            canAttack = false;
        }
        else if(chargeAmounts == 1 && player.fireBookHeld)
        {
            fire1.SetActive(true);
            fire2.SetActive(false);
            fire3.SetActive(false);
            canAttack = true;
        } else if(chargeAmounts == 2 && player.fireBookHeld)
        {
            fire1.SetActive(true);
            fire2.SetActive(true);
            fire3.SetActive(false);
            canAttack = true;
        } else if (chargeAmounts == 3 && player.fireBookHeld)
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
        if (chargeAmounts == 0 && player.iceBookHeld)
        {
            player.ice1.SetActive(false);
            player.ice2.SetActive(false);
            player.ice3.SetActive(false);
            canAttack = false;
        }
        else if (chargeAmounts == 1 && player.iceBookHeld)
        {

            player.ice1.SetActive(true);
            player.ice2.SetActive(false);
            player.ice3.SetActive(false);
            canAttack = true;
        }
        else if (chargeAmounts == 2 && player.iceBookHeld)
        {
            player.ice1.SetActive(true);
            player.ice2.SetActive(true);
            player.ice3.SetActive(false);
            canAttack = true;
        }
        else if (chargeAmounts == 3 && player.iceBookHeld)
        {
            player.ice1.SetActive(true);
            player.ice2.SetActive(true);
            player.ice3.SetActive(true);
            canAttack = true;
        }
        if (chargeAmounts >= 4)
        {
            chargeAmounts = 3;
        }

    }

    IEnumerator AttackWaitFireball (float seconds)
    {
        canAttack = false;
        fireballSource.PlayOneShot(fireballSound);
        yield return new WaitForSeconds(seconds);
        canAttack = true;

    }
    IEnumerator AttackWaitIce(float seconds)
    {
        canAttack = false;
        fireballSource.PlayOneShot(iceSound);
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
