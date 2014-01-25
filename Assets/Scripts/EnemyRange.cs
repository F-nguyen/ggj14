using UnityEngine;
using System.Collections;

public class EnemyRange : MonoBehaviour {
	Enemy enemy;

	public float loseInterestTime = 3f;

	float loseInterestCount;
	bool losingInterest = false;

	// Use this for initialization
	void Start () {
		enemy = transform.parent.gameObject.GetComponent<Enemy>();
		loseInterestCount = loseInterestTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (losingInterest) {
			loseInterestCount -= Time.deltaTime;

			if (loseInterestCount <= 0) {
				enemy.target = null;
				losingInterest = false;
				//loseInterestCount = loseInterestTime;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Debug.Log ("Range Trigger Entered " + collider.gameObject.name);
		if (collider.gameObject.tag == "Player") {
			Debug.Log("WUT");
			losingInterest = false;
			enemy.target = collider.gameObject;
		}
	}
	
	//void OnTriggerStay2D(Collider2D collider) {
	//	Debug.Log ("Triggered");
	//}
	
	void OnTriggerExit2D(Collider2D collider) {
		if (enemy.target && collider.gameObject == enemy.target) {
			losingInterest = true;
			loseInterestCount = loseInterestTime;
		}
		Debug.Log ("Range Trigger Left");
	}
}
