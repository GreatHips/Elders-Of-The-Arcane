using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellButton : MonoBehaviour
{
    private GameObject player;
    public Player playerComp;

    public void Start()
    {
        player = GameObject.Find("Player");
        playerComp = player.GetComponent<Player>();
    }

    public void UseIce()
    {
        playerComp.iceBookHeld = true;
        playerComp.fireBookHeld = false;
        playerComp.speedBookHeld = false;
    }
    public void UseFire()
    {
        playerComp.iceBookHeld = false;
        playerComp.fireBookHeld = true;
        playerComp.speedBookHeld = false;
    }
    public void UseSpeed()
    {
        playerComp.iceBookHeld = false;
        playerComp.fireBookHeld = false;
        playerComp.speedBookHeld = true;
    }
}
