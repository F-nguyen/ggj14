using UnityEngine;
using InControl;

public class Player : MonoBehaviour 
{
	[SerializeField] float maxSpeed = 10f;				// The fastest the player can travel in the x axis.

	//Animator anim;										// Reference to the player's animator component.

	void Awake()
	{
		//anim = GetComponent<Animator>();
	}
	
	
	void FixedUpdate()
	{
		// Set the vertical animation
		//anim.SetFloat("vSpeed", rigidbody2D.velocity.y);

		InputDevice device = InputManager.ActiveDevice;
		Debug.Log (device.Direction.x);
		Debug.Log (device.Direction.y);

		//Debug.Log (device.Direction.sqrMagnitude);

		//if (device.Direction.x != 0f && device.Direction.y != 0f) {
		//	transform.rotation = Quaternion.LookRotation(device.Direction, Vector2.up);
		//}
		//Debug.Log (Mathf.Atan2(device.Direction.y, device.Direction.x));
		float rotationAngle = (Mathf.Atan2 (device.Direction.y, device.Direction.x) * Mathf.Rad2Deg);
		Debug.Log (rotationAngle);
		Debug.Log ("------");
		// Pass all parameters to the character control script.
		Move(device.Direction);
	}
	
	
	public void Move(Vector2 movement)
	{
		// The Speed animator parameter is set to the absolute value of the horizontal input.
		//anim.SetFloat("Speed", Mathf.Abs(move));
		
		// Move the character
		rigidbody2D.velocity = movement * maxSpeed;
	}
}
