using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject target;
	public bool chasing = false;
	public float shootDelay = 1f;
	public EnemyBullet bullet;
	public bool attackingBase = false;

	float shootCounter;
	GameObject mainTarget;


	void Start () {
		target = GameObject.FindGameObjectWithTag("MainTarget");
		mainTarget = GameObject.FindGameObjectWithTag("MainTarget");
		shootCounter = shootDelay;
	}

	void FixedUpdate() {
		if (target)
			rigidbody2D.velocity = transform.right * 5f;
	}
	
	void Update () {
		if (target) {
			float rotationAngle = (Mathf.Atan2 (target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg);
			transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, rotationAngle));
		}

		// Handle shooting.
		shootCounter -= Time.deltaTime;
		if (chasing) {
			if (shootCounter <= 0f) {
				shootCounter = shootDelay;
				float bulletRotation = (Mathf.Atan2 (target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg);
				EnemyBullet bulletComponent = (Instantiate (bullet, transform.position, Quaternion.Euler (new Vector3 (0f, 0f, bulletRotation))) as GameObject).GetComponent<EnemyBullet> ();
				//bulletComponent.movementDirection = rightStick.normalized;
			}
		} else {
			if (target != mainTarget)
				target = mainTarget;
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "MainTarget") {
			chasing = true;
			attackingBase = true;
			target = mainTarget;
			gameObject.GetComponentInChildren<EnemyRange>().enabled = false;
		}
	}

	//void OnCollisionStay2D(Collision2D collision) {
	//	Debug.Log ("Collided");
	//}


}
