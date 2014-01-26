using UnityEngine;
using System.Collections;

public class SpawnZone : MonoBehaviour {
	public float minSpawnTime = 1;
	public float maxSpawnTime = 5;
	public Enemy[] spawnableEnemies;

	float spawnCounter = 0;

	void Start() {
		spawnCounter = Random.Range (minSpawnTime, maxSpawnTime);
	}
	
	void Update () {
		spawnCounter -= Time.deltaTime;

		if (spawnCounter <= 0f) {
			Vector2 extents = GetComponent<BoxCollider2D>().size * 0.5f;
			Vector2 topLeft = new Vector2(transform.position.x - extents.x, transform.position.y + extents.y);
			Vector2 bottomRight = new Vector2(transform.position.x + extents.x, transform.position.y - extents.y);

			Instantiate(spawnableEnemies [Random.Range (0, spawnableEnemies.Length)], new Vector3(Random.Range(topLeft.x, bottomRight.x), Random.Range(bottomRight.y, topLeft.y), 0f), Quaternion.identity);
			spawnCounter = Random.Range(minSpawnTime, maxSpawnTime);
		}
	}
}
