using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    public GameObject fireball;
    public GameObject ice;
    public GameObject speed;
    public Player player;
    GameObject b;
    public bool canAttack = true;
    public int chargeAmounts = Mathf.Max(3);
    public GameObject inventory;

    public AudioClip fireballSound;
    public AudioClip iceSound;

    public AudioSource iceSource;
    public AudioSource fireballSource;

    public bool Charging = false;

    public int varFacingRight;
    public void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 11);
    }
    private void Update()
    {
        
        checkBookHeld();
        varFacingRight = 1;

        if (player.facingRight == false)
        {
            varFacingRight = -1;

        }
        if (canAttack && chargeAmounts >= 1)
        {
            if (Input.GetKeyDown(KeyCode.K) || (Input.GetKeyDown(KeyCode.L)))
            {

                chargeAmounts -= 1;


                if (player.fireBookHeld)
                {
                    ShootFireball();
                }
                if (player.iceBookHeld)
                {
                    ShootIce();
                }
                if (player.speedBookHeld)
                {
                    ShootSpeed();
                }
            }
        }
    }

    void ShootSpeed()
    {
        GameObject bspeed = (GameObject)(Instantiate(speed, transform.position, Quaternion.identity));
        bspeed.transform.parent = player.transform;
        bspeed.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        player.moveSpeed = 16;
        StartCoroutine(SpeedChange());
        StartCoroutine(SpeedRecharge());

        Destroy(bspeed, 1.5f);
    }

    void ShootFireball()
    {
        GameObject bfire = (GameObject)(Instantiate(fireball, transform.position + transform.up * .45f + transform.right * varFacingRight * -2f, Quaternion.identity));
        bfire.GetComponent<Rigidbody2D>().AddForce(transform.right * varFacingRight * -1000);
        fireballSource.Play();
        StartCoroutine(RechargeFireball());

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

    void ShootIce()
    {
        GameObject bice = (GameObject)(Instantiate(ice, transform.position + transform.up * 3f + transform.right * varFacingRight * -3f, Quaternion.identity));
        GameObject bice2 = (GameObject)(Instantiate(ice, transform.position + transform.up * 3f + transform.right * varFacingRight * -3.5f, Quaternion.identity));
        GameObject bice3 = (GameObject)(Instantiate(ice, transform.position + transform.up * 3f + transform.right * varFacingRight * -4f, Quaternion.identity));
        bice.GetComponent<Rigidbody2D>().AddForce(transform.up * -1);
        bice2.GetComponent<Rigidbody2D>().AddForce(transform.up * -1);
        bice3.GetComponent<Rigidbody2D>().AddForce(transform.up * -1);

        StartCoroutine(RechargeIce());


        Destroy(bice, 2f);
        Destroy(bice2, 2f);
        Destroy(bice3, 2f);
    }

    IEnumerator RechargeFireball()
    {

        while (chargeAmounts == 0 && !Charging && player.fireBookHeld)
        {
            Charging = true;
            yield return new WaitForSeconds(.75f);
            chargeAmounts += 1;
            Charging = false;

        }
        while (chargeAmounts == 1 && !Charging && player.fireBookHeld)
        {
            Charging = true;
            yield return new WaitForSeconds(.75f);
            chargeAmounts += 1;
            Charging = false;

        }
        while (chargeAmounts == 2 && !Charging && player.fireBookHeld)
        {
            Charging = true;
            yield return new WaitForSeconds(.75f);
            chargeAmounts += 1;
            Charging = false;
        }

        if (chargeAmounts == 1 && !Charging && player.fireBookHeld)
        {
            Charging = true;
            yield return new WaitForSeconds(.75f);
            chargeAmounts += 1;
            Charging = false;
        }
        if (chargeAmounts == 2 && !Charging && player.fireBookHeld)
        {
            Charging = true;
            yield return new WaitForSeconds(.75f);
            chargeAmounts += 1;
            Charging = false;
        }

        if (chargeAmounts > 4 && player.fireBookHeld)
        {
            chargeAmounts = 3;
        }

    }
    IEnumerator RechargeIce()
    {

        while (chargeAmounts == 0 && !Charging && player.iceBookHeld)
        {
            Charging = true;
            yield return new WaitForSeconds(1f);
            chargeAmounts += 1;
            Charging = false;

        }
        while (chargeAmounts == 1 && !Charging && player.iceBookHeld)
        {
            Charging = true;
            yield return new WaitForSeconds(1f);
            chargeAmounts += 1;
            Charging = false;

        }
        while (chargeAmounts == 2 && !Charging && player.iceBookHeld)
        {
            Charging = true;
            yield return new WaitForSeconds(1f);
            chargeAmounts += 1;
            Charging = false;
        }

        if (chargeAmounts == 1 && !Charging && player.iceBookHeld)
        {
            Charging = true;
            yield return new WaitForSeconds(1f);
            chargeAmounts += 1;
            Charging = false;
        }
        if (chargeAmounts == 2 && !Charging && player.iceBookHeld)
        {
            Charging = true;
            yield return new WaitForSeconds(1f);
            chargeAmounts += 1;
            Charging = false;
        }

        if (chargeAmounts > 4 && player.iceBookHeld)
        {
            chargeAmounts = 3;
        }

    }
    IEnumerator SpeedRecharge()
    {
        while (chargeAmounts == 0 && !Charging && player.speedBookHeld)
        {
            Charging = true;
            yield return new WaitForSeconds(7f);
            chargeAmounts += 1;
            Charging = false;

        }
        while (chargeAmounts == 1 && !Charging && player.speedBookHeld)
        {
            Charging = true;
            yield return new WaitForSeconds(7f);
            chargeAmounts += 1;
            Charging = false;

        }
        while (chargeAmounts == 2 && !Charging && player.speedBookHeld)
        {
            Charging = true;
            yield return new WaitForSeconds(7f);
            chargeAmounts += 1;
            Charging = false;
        }

        if (chargeAmounts == 1 && !Charging && player.speedBookHeld)
        {
            Charging = true;
            yield return new WaitForSeconds(7f);
            chargeAmounts += 1;
            Charging = false;
        }
        if (chargeAmounts == 2 && !Charging && player.speedBookHeld)
        {
            Charging = true;
            yield return new WaitForSeconds(7f);
            chargeAmounts += 1;
            Charging = false;
        }

        if (chargeAmounts > 4 && player.speedBookHeld)
        {
            chargeAmounts = 3;
        }

    }
    IEnumerator SpeedChange()
    {
        yield return new WaitForSeconds(1.5f);
        player.moveSpeed = 6.5f;
    }
    void checkBookHeld()
    {

        if (inventory.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                player.bookHeldInt += 1;
                if (player.bookHeldInt >= 4)
                {
                    player.bookHeldInt = 1;
                }
            }
        }

        if (player.bookHeldInt == 1)
        {
            player.fireBookHeld = true;
            player.iceBookHeld = false;
            player.speedBookHeld = false;
        }
        if (player.bookHeldInt == 2)
        {
            player.fireBookHeld = false;
            player.iceBookHeld = true;
            player.speedBookHeld = false;
        }
        if (player.bookHeldInt == 3)
        {
            player.fireBookHeld = false;
            player.iceBookHeld = false;
            player.speedBookHeld = true;
        }
        if (chargeAmounts == 0 && player.fireBookHeld)
        {
            player.fire1.SetActive(false);
            player.fire2.SetActive(false);
            player.fire3.SetActive(false);
            player.ice1.SetActive(false);
            player.ice2.SetActive(false);
            player.ice3.SetActive(false);
            player.fireballText.SetActive(true);
            player.iceText.SetActive(false);
            player.speed1.SetActive(false);
            player.speed2.SetActive(false);
            player.speed3.SetActive(false);
            player.fireBook.SetActive(true);
            player.iceBook.SetActive(false);
            player.speedBook.SetActive(false);
            player.speedText.SetActive(false);
            canAttack = false;
        }
        else if (chargeAmounts == 1 && player.fireBookHeld)
        {
            player.fire1.SetActive(true);
            player.fire2.SetActive(false);
            player.fire3.SetActive(false);
            player.ice1.SetActive(false);
            player.ice2.SetActive(false);
            player.ice3.SetActive(false);
            player.fireballText.SetActive(true);
            player.iceText.SetActive(false);
            player.speed1.SetActive(false);
            player.speed2.SetActive(false);
            player.speed3.SetActive(false);
            player.fireBook.SetActive(true);
            player.iceBook.SetActive(false);
            player.speedBook.SetActive(false);
            player.speedText.SetActive(false);
            canAttack = true;
        }
        else if (chargeAmounts == 2 && player.fireBookHeld)
        {
            player.fire1.SetActive(true);
            player.fire2.SetActive(true);
            player.fire3.SetActive(false);
            player.ice1.SetActive(false);
            player.ice2.SetActive(false);
            player.ice3.SetActive(false);
            player.fireballText.SetActive(true);
            player.iceText.SetActive(false);
            player.speed1.SetActive(false);
            player.speed2.SetActive(false);
            player.speed3.SetActive(false);
            player.fireBook.SetActive(true);
            player.iceBook.SetActive(false);
            player.speedBook.SetActive(false);
            player.speedText.SetActive(false);
            canAttack = true;
        }
        else if (chargeAmounts == 3 && player.fireBookHeld)
        {
            player.fire1.SetActive(true);
            player.fire2.SetActive(true);
            player.fire3.SetActive(true);
            player.ice1.SetActive(false);
            player.ice2.SetActive(false);
            player.ice3.SetActive(false);
            player.fireballText.SetActive(true);
            player.iceText.SetActive(false);
            player.speed1.SetActive(false);
            player.speed2.SetActive(false);
            player.speed3.SetActive(false);
            player.fireBook.SetActive(true);
            player.iceBook.SetActive(false);
            player.speedBook.SetActive(false);
            player.speedText.SetActive(false);
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
            player.fire1.SetActive(false);
            player.fire2.SetActive(false);
            player.fire3.SetActive(false);
            player.fireballText.SetActive(false);
            player.iceText.SetActive(true);
            player.speed1.SetActive(false);
            player.speed2.SetActive(false);
            player.speed3.SetActive(false);
            player.fireBook.SetActive(false);
            player.iceBook.SetActive(true);
            player.speedBook.SetActive(false);
            player.speedText.SetActive(false);
            canAttack = false;
        }
        else if (chargeAmounts == 1 && player.iceBookHeld)
        {

            player.ice1.SetActive(true);
            player.ice2.SetActive(false);
            player.ice3.SetActive(false);
            player.fire1.SetActive(false);
            player.fire2.SetActive(false);
            player.fire3.SetActive(false);
            player.fireballText.SetActive(false);
            player.iceText.SetActive(true);
            player.speed1.SetActive(false);
            player.speed2.SetActive(false);
            player.speed3.SetActive(false);
            player.fireBook.SetActive(false);
            player.iceBook.SetActive(true);
            player.speedBook.SetActive(false);
            player.speedText.SetActive(false);
            canAttack = true;
        }
        else if (chargeAmounts == 2 && player.iceBookHeld)
        {
            player.ice1.SetActive(true);
            player.ice2.SetActive(true);
            player.ice3.SetActive(false);
            player.fire1.SetActive(false);
            player.fire2.SetActive(false);
            player.fire3.SetActive(false);
            player.fireballText.SetActive(false);
            player.iceText.SetActive(true);
            player.speed1.SetActive(false);
            player.speed2.SetActive(false);
            player.speed3.SetActive(false);
            player.fireBook.SetActive(false);
            player.iceBook.SetActive(true);
            player.speedBook.SetActive(false);
            player.speedText.SetActive(false);
            canAttack = true;
        }
        else if (chargeAmounts == 3 && player.iceBookHeld)
        {
            player.ice1.SetActive(true);
            player.ice2.SetActive(true);
            player.ice3.SetActive(true);
            player.fire1.SetActive(false);
            player.fire2.SetActive(false);
            player.fire3.SetActive(false);
            player.fireballText.SetActive(false);
            player.iceText.SetActive(true);
            player.speed1.SetActive(false);
            player.speed2.SetActive(false);
            player.speed3.SetActive(false);
            player.fireBook.SetActive(false);
            player.iceBook.SetActive(true);
            player.speedBook.SetActive(false);
            player.speedText.SetActive(false);
            canAttack = true;
        }
        if (chargeAmounts >= 4)
        {
            chargeAmounts = 3;
        }
        if (chargeAmounts == 0 && player.speedBookHeld)
        {
            player.ice1.SetActive(false);
            player.ice2.SetActive(false);
            player.ice3.SetActive(false);
            player.fire1.SetActive(false);
            player.fire2.SetActive(false);
            player.fire3.SetActive(false);
            player.fireballText.SetActive(false);
            player.iceText.SetActive(false);
            player.speed1.SetActive(false);
            player.speed2.SetActive(false);
            player.speed3.SetActive(false);
            player.fireBook.SetActive(false);
            player.iceBook.SetActive(false);
            player.speedBook.SetActive(true);
            player.speedText.SetActive(true);
            canAttack = false;
        }
        else if (chargeAmounts == 1 && player.speedBookHeld)
        {

            player.ice1.SetActive(false);
            player.ice2.SetActive(false);
            player.ice3.SetActive(false);
            player.fire1.SetActive(false);
            player.fire2.SetActive(false);
            player.fire3.SetActive(false);
            player.fireballText.SetActive(false);
            player.iceText.SetActive(false);
            player.speed1.SetActive(true);
            player.speed2.SetActive(false);
            player.speed3.SetActive(false);
            player.fireBook.SetActive(false);
            player.iceBook.SetActive(false);
            player.speedBook.SetActive(true);
            player.speedText.SetActive(true);
            canAttack = true;
        }
        else if (chargeAmounts == 2 && player.speedBookHeld)
        {
            player.ice1.SetActive(false);
            player.ice2.SetActive(false);
            player.ice3.SetActive(false);
            player.fire1.SetActive(false);
            player.fire2.SetActive(false);
            player.fire3.SetActive(false);
            player.fireballText.SetActive(false);
            player.iceText.SetActive(false);
            player.speed1.SetActive(true);
            player.speed2.SetActive(true);
            player.speed3.SetActive(false);
            player.fireBook.SetActive(false);
            player.iceBook.SetActive(false);
            player.speedBook.SetActive(true);
            player.speedText.SetActive(true);
            canAttack = true;
        }
        else if (chargeAmounts == 3 && player.speedBookHeld)
        {
            player.ice1.SetActive(false);
            player.ice2.SetActive(false);
            player.ice3.SetActive(false);
            player.fire1.SetActive(false);
            player.fire2.SetActive(false);
            player.fire3.SetActive(false);
            player.fireballText.SetActive(false);
            player.iceText.SetActive(false);
            player.speed1.SetActive(true);
            player.speed2.SetActive(true);
            player.speed3.SetActive(true);
            player.fireBook.SetActive(false);
            player.iceBook.SetActive(false);
            player.speedBook.SetActive(true);
            player.speedText.SetActive(true);
            canAttack = true;
        }
        if (chargeAmounts >= 4)
        {
            chargeAmounts = 3;
        }
    }
}

