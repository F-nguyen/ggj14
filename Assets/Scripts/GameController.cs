using UnityEngine;
using System.Collections;
using InControl;

public class GameController : MonoBehaviour {
	float playTime = 0;
	bool baseDestroyed = false;
	// Use this for initialization
	void Start () {
	
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
	}

	void OnGUI () {
		GUI.Label (new Rect (0,100,200,50), "Time: " + playTime);
	}

	void BaseDestroyed() {
		baseDestroyed = true;
	}
}
