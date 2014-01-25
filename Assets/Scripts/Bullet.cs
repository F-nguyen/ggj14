using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public Vector3 movementDirection = new Vector2(0, 0);
	public float speed = 5f;

	void FixedUpdate()
	{
		rigidbody2D.velocity = transform.right * speed;
		//rigidbody2D.velocity = movementDirection * speed;
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Enemy") {
			Destroy(collider.gameObject);
			Destroy(gameObject);
		}
	}

}
