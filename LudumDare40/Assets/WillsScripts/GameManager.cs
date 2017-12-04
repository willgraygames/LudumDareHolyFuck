using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance { get; protected set; }

	public int gemCount;
	public int asteroidCount;
	public int enemyCount;
	public int maxEnemyCount;

	public GameObject[] gems;
	public GameObject asteroid;
	public GameObject[] enemies;

	void Awake () {
		if (Instance != null) {
			print ("There should only be one Game Manager");
		} else {
			Instance = this;
		}

		SimplePool.Preload (gems [0], 30);
		SimplePool.Preload (gems [1], 20);
		SimplePool.Preload (gems [2], 20);
		SimplePool.Preload (gems [3], 10);
		SimplePool.Preload (asteroid, 40);
		SimplePool.Preload (enemies [0], 20);
		SimplePool.Preload (enemies [1], 20);
		SimplePool.Preload (enemies [2], 20);
	}

	void Update () {
		DetermineEnemyCount ();
		if (asteroidCount < 40) {
			SpawnAsteroid ();
		}
		if (enemyCount < maxEnemyCount) {
			StartCoroutine (SpawnEnemy ());
			enemyCount += 1;
		}
	}

	void SpawnAsteroid () {
		float xPos = Random.Range (-50, 50);
		float yPos = Random.Range (-50, 50);
		Vector3 spawnPosition = new Vector3 (xPos, yPos, 0);
		SimplePool.Spawn (asteroid, spawnPosition, Quaternion.identity);
		asteroidCount += 1;
	}

	IEnumerator SpawnEnemy () {
		yield return new WaitForSeconds (2);
		int rv = Random.Range (0, 10);
		float xPos = Random.Range (-50, 50);
		float yPos = Random.Range (-50, 50);
		Vector3 spawnPosition = new Vector3 (xPos, yPos, 0);
		if (rv <= 5) {
			SimplePool.Spawn (enemies [0], spawnPosition, Quaternion.identity);
		} else if (rv <= 8 && rv > 5) {
			SimplePool.Spawn (enemies [1], spawnPosition, Quaternion.identity);
		} else {
			SimplePool.Spawn (enemies [2], spawnPosition, Quaternion.identity);
		}
	}

	void DetermineEnemyCount () {
		maxEnemyCount = gemCount / 10;
	}
}
