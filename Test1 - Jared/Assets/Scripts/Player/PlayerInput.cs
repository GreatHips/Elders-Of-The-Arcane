using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

	Player player;
    public GameObject inventory;
    public GameObject hearts;
    void Start () {
		player = GetComponent<Player> ();
	}

	void Update () {
		Vector2 directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		player.SetDirectionalInput (directionalInput);

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) {
			player.OnJumpInputDown ();
		}
		if (Input.GetKeyUp (KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) {
			player.OnJumpInputUp ();
		}
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            player.OnShiftDown();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            player.OnShiftUp();
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
