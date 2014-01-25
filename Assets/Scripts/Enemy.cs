using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate() {
		rigidbody2D.velocity = transform.right * 5f;
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log (Vector2.MoveTowards (transform.position, player.transform.position, 5));
		//transform.LookAt(player.transform.position);
		//Vector3 test = Vector3.MoveTowards(transform.position, target.position, step);

		Quaternion targetRot = Quaternion.LookRotation(transform.forward, player.transform.position - transform.position);

		Quaternion inter = Quaternion.Slerp (transform.rotation, targetRot, 5 * Time.deltaTime);

		transform.rotation = Quaternion.Euler(inter.eulerAngles + new Vector3(0, 0, 90f));
	}
}
