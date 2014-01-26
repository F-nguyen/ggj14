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
				enemy.chasing = false;
				//loseInterestCount = loseInterestTime;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (!enemy.attackingBase && collider.gameObject.tag == "Player") {
			losingInterest = false;
			enemy.target = collider.gameObject;
			enemy.chasing = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D collider) {
		if (!enemy.attackingBase && enemy.target && collider.gameObject == enemy.target) {
			losingInterest = true;
			loseInterestCount = loseInterestTime;
		}
	}
}
