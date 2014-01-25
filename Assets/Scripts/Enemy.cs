using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject target;

	void Start () {
		//target = GameObject.FindGameObjectWithTag("Player");
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
	}

	//void OnCollisionStay2D(Collision2D collision) {
	//	Debug.Log ("Collided");
	//}


}
