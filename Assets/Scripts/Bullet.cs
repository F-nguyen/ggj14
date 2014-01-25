using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public Vector2 movementDirection = new Vector2(0, 0);
	public float speed = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		rigidbody2D.velocity = movementDirection * 5;
	}
}
