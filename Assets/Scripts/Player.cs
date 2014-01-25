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

		// Read the inputs.
		//bool crouch = Input.GetKey(KeyCode.LeftControl);
		//float h = CrossPlatformInput.GetAxis("Horizontal");
		InputDevice device = InputManager.ActiveDevice;
		Debug.Log (device);
		// Pass all parameters to the character control script.
		//Move(h);
	}
	
	
	public void Move(float move)
	{
		// The Speed animator parameter is set to the absolute value of the horizontal input.
		//anim.SetFloat("Speed", Mathf.Abs(move));
		
		// Move the character
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
	}
}
