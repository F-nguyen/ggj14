using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {
	public int health = 500;
	private GameObject gameController;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUI.Label (new Rect (0,0,200,50), "Base Health: " + health);
	}

	public void Hit(int damage) {
		health -= damage;
		if (health <= 0) {
			gameController.SendMessage("BaseDestroyed");
			Destroy (gameObject);
		}
	}

	void BoostHealth() {
		health = 100000;
	}
}
