﻿using UnityEngine;
using InControl;

public class Player : MonoBehaviour 
{
	public GameObject bullet;
	public float shootDelay = 0.25f;
	public int health = 10;
	[SerializeField] float maxSpeed = 10f;				// The fastest the player can travel in the x axis.

	Animator animator;									// Reference to the player's animator component.

	float rotationAngle = 0f;
	float shootCounter = 0f;
	bool dead = false;
	void Awake()
	{
		shootCounter = shootDelay;
		animator = GetComponent<Animator>();
	}
	
	
	void FixedUpdate()
	{
		if (!dead) {
			InputDevice device = InputManager.ActiveDevice;

			Move (device.Direction);

			//Debug.Log (rigidbody2D.velocity.sqrMagnitude);
			animator.SetBool ("Hit", false);
			animator.SetFloat ("Speed", rigidbody2D.velocity.sqrMagnitude);
		}
	}

	public void Update() {
		if (!dead) {
			InputDevice device = InputManager.ActiveDevice;
			if (device.Direction != Vector2.zero)
				rotationAngle = (Mathf.Atan2 (device.Direction.y, device.Direction.x) * Mathf.Rad2Deg);

			transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, rotationAngle));

			// Handle Shooting
			shootCounter += Time.deltaTime;
			Vector2 rightStick = device.RightStickVector;
			if (rightStick != Vector2.zero) {
				if (shootCounter >= shootDelay) {
					float bulletRotation = (Mathf.Atan2 (rightStick.y, rightStick.x) * Mathf.Rad2Deg);
					Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0f, 0f, bulletRotation)));
					//bulletComponent.movementDirection = rightStick.normalized;

					shootCounter = 0f;
				}
			}
		}
	}
	
	
	public void Move(Vector2 movement) {
		// The Speed animator parameter is set to the absolute value of the horizontal input.
		//anim.SetFloat("Speed", Mathf.Abs(move));
		
		// Move the character
		rigidbody2D.velocity = movement * maxSpeed;
	}

	public void Hit(int damage) {
		health -= damage;
		if (health <= 0f)
			Death ();
		else
			animator.Play ("Hit");
				
	}

	public void BoostHealth() {
		health = 100000;
	}

	public void Death() {
		dead = true;
		GameObject.FindWithTag("GameController").SendMessage("BaseDestroyed");
		animator.Play ("Explosion");
	}

	public void DestroyPlayer() {
		Destroy(gameObject);
	}

	void OnGUI () {
		GUI.Label (new Rect (0,50,200,50), "Player Health: " + health);
	}
}
