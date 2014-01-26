using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {
	public Vector3 movementDirection = new Vector2(0, 0);
	public float speed = 5f;
	public GameObject creator;

	void FixedUpdate()
	{
		rigidbody2D.velocity = transform.right * speed;
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			collider.gameObject.SendMessage("Hit", 1);
			Destroy(gameObject);
		}
		if (collider.gameObject.tag == "MainTarget") {
			//Destroy(collider.gameObject);
			collider.gameObject.SendMessage("Hit", 1);
			Destroy(gameObject);
		}

		if (collider.gameObject.tag == "Enemy" && collider.gameObject != creator) {
			//Destroy(collider.gameObject);
			collider.gameObject.SendMessage("Hit", 1);
			Destroy(gameObject);
		}
	}

}
