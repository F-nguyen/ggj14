using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public Vector3 movementDirection = new Vector2(0, 0);
	public float speed = 5f;
	public float lifeTime = 4f;

	void FixedUpdate()
	{
		rigidbody2D.velocity = transform.right * speed;
		//rigidbody2D.velocity = movementDirection * speed;
	}

	void Update() {
		lifeTime -= Time.deltaTime;
		if (lifeTime <= 0f)
			Destroy (gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Enemy") {
			collider.gameObject.SendMessage("Hit", 1);
			Destroy(gameObject);
		}
	}

}
