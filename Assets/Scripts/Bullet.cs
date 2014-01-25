using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public Vector2 movementDirection = new Vector2(0, 0);
	public float speed = 5f;

	void FixedUpdate()
	{
		rigidbody2D.velocity = movementDirection * 5;
	}


	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Enemy") {
			Destroy(collider.gameObject);
			Destroy(gameObject);
		}
	}
}
