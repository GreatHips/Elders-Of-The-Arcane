using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

	Player player;
    public GameObject inventory;
    public GameObject hearts;
    private GameObject players;
    void Start () {
		player = GetComponent<Player>();
	}

	void Update () {

        var players = GameObject.Find("Player");
        if (Input.GetKeyDown(KeyCode.F))
        {
            players.GetComponent<HealthManager>().healthMax += 100000;
            players.GetComponent<HealthManager>().health += 1000000;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            players.GetComponent<HealthManager>().healthMax -= 10;
            players.GetComponent<HealthManager>().health -= 10;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            player.GetComponent<Player>().moveSpeed = 299792459;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            player.GetComponent<Player>().moveSpeed = 6.5f;
        }

        Vector2 directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		player.SetDirectionalInput (directionalInput);

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) {
			player.OnJumpInputDown ();
		}
		if (Input.GetKeyUp (KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) {
			player.OnJumpInputUp ();
		}
        if (Input.GetKeyUp(KeyCode.M))
        {
            Mail.SendMail();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventory.SetActive(true);
            hearts.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            inventory.SetActive(false);
            hearts.SetActive(true);

        }
    }
}
