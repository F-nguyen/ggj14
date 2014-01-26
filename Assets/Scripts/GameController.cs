using UnityEngine;
using System.Collections;
using InControl;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		InputDevice device = InputManager.ActiveDevice;
		if (device.Action4.WasPressed)
			Application.LoadLevel (0);
	}
}
