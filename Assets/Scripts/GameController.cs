using UnityEngine;
using System.Collections;
using InControl;

public class GameController : MonoBehaviour {
	float playTime = 0;
	bool baseDestroyed = false;

	GameObject player;
	GameObject mainTarget;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		mainTarget = GameObject.FindWithTag("MainTarget");
	}
	
	// Update is called once per frame
	void Update () {
		if (!baseDestroyed)
			playTime += Time.deltaTime;
	}

	void FixedUpdate() {
		InputDevice device = InputManager.ActiveDevice;
		if (device.Action4.WasPressed)
			Application.LoadLevel (0);
		if (device.Action2.WasPressed) {

			mainTarget.SendMessage("BoostHealth");
			//Debug.Log("Found player", player);
			//Debug.Log (GameObject.FindWithTag("Player"));
			//Debug.Log (GameObject.FindWithTag("Play"));
			//GameObject play = GameObject.FindWithTag("Player");
			player.SendMessage("BoostHealth");
			//player.SendMessage("BoostHealth"); // Busted for some reason.
			//GameObject.FindWithTag("Player").GetComponent<Player>().BoostHealth();
		}
	}

	void OnGUI () {
		GUI.Label (new Rect (0,100,200,50), "Time: " + playTime);
	}

	void BaseDestroyed() {
		baseDestroyed = true;
	}
}
