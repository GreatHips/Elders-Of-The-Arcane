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

    public bool Charging = false;

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

                
                if (player.fireBookHeld == true)
                {
                    GameObject bfire = (GameObject)(Instantiate(fireball, transform.position + transform.right * varFacingRight * -2f, Quaternion.identity));
                    bfire.GetComponent<Rigidbody2D>().AddForce(transform.right * varFacingRight * -1000);

                    StartCoroutine(Recharge());

                    StartCoroutine(AttackWaitFireball());

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
                    GameObject bice = (GameObject)(Instantiate(ice, transform.position + transform.up + transform.right * varFacingRight * -2f, Quaternion.identity));

                    bice.GetComponent<Rigidbody2D>().AddForce(-transform.up * 10000f);

                    StartCoroutine(Recharge());

                    StartCoroutine(AttackWaitIce());

                    if (varFacingRight == 1)
                    {
                        bice.transform.Rotate(0, 0, 180f);
                    }
                    else if (varFacingRight == -1)
                    {
                        bice.transform.Rotate(0, 0, 180f);
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

    IEnumerator AttackWaitFireball ()
    {
        canAttack = false;

        fireballSource.PlayOneShot(fireballSound);
        fireballSource.pitch = 1f;

        yield return new WaitForSeconds(.5f);

        canAttack = true;

    }
    IEnumerator AttackWaitIce()
    {
        canAttack = false;

        iceSource.PlayOneShot(iceSound);
        iceSource.pitch = 1f;

        yield return new WaitForSeconds(.75f);

        canAttack = true;

    }

    IEnumerator Recharge ()
    {

        while (chargeAmounts == 0 && !Charging)
        {
            Charging = true;
            yield return new WaitForSeconds(1.5f);
            chargeAmounts += 1;
            Charging = false;

        }
          while (chargeAmounts == 1 && !Charging)
        {
            Charging = true;
            yield return new WaitForSeconds(1.5f);
            chargeAmounts += 1;
            Charging = false;

        } 
        while (chargeAmounts == 2 && !Charging)
        {
            Charging = true;
            yield return new WaitForSeconds(1.5f);
            chargeAmounts += 1;
            Charging = false;
        }

        if (chargeAmounts == 1 && !Charging)
        {
            Charging = true;
            yield return new WaitForSeconds(1.5f);
            chargeAmounts += 1;
            Charging = false;
        }
        if (chargeAmounts == 2 && !Charging)
        {
            Charging = true;
            yield return new WaitForSeconds(1.5f);
            chargeAmounts += 1;
            Charging = false;
        }

        if (chargeAmounts > 4)
        {
            chargeAmounts = 3;
        }

    }
}
