using UnityEngine;
using InControl;

public class Player : MonoBehaviour 
{
	public GameObject bullet;
	public float shootDelay = 0.25f;

	[SerializeField] float maxSpeed = 10f;				// The fastest the player can travel in the x axis.

	Animator animator;									// Reference to the player's animator component.

	float rotationAngle = 0f;
	float shootCounter = 0f;

	void Awake()
	{
		shootCounter = shootDelay;
		animator = GetComponent<Animator>();
	}
	
	
	void FixedUpdate()
	{
		InputDevice device = InputManager.ActiveDevice;

		Move(device.Direction);

		//Debug.Log (rigidbody2D.velocity.sqrMagnitude);
		animator.SetFloat("Speed", rigidbody2D.velocity.sqrMagnitude);
	}

	public void Update() {
		InputDevice device = InputManager.ActiveDevice;
		if (device.Direction != Vector2.zero)
			rotationAngle = (Mathf.Atan2 (device.Direction.y, device.Direction.x) * Mathf.Rad2Deg);

		transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, rotationAngle));

		// Handle Shooting
		shootCounter += Time.deltaTime;
		Vector2 rightStick = device.RightStickVector;
		if (rightStick != Vector2.zero) {
			if (shootCounter >= shootDelay) {
				Bullet bulletComponent = (Instantiate(bullet, transform.position, Quaternion.identity) as GameObject).GetComponent<Bullet>();
				bulletComponent.movementDirection = rightStick.normalized;
				shootCounter = 0f;
			}
		}
	}
	
	
	public void Move(Vector2 movement)
	{
		// The Speed animator parameter is set to the absolute value of the horizontal input.
		//anim.SetFloat("Speed", Mathf.Abs(move));
		
		// Move the character
		rigidbody2D.velocity = movement * maxSpeed;
	}
}
