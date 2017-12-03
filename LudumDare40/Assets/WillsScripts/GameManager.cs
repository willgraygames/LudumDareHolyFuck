using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance { get; protected set; }

	public int gemCount;
	public int asteroidCount;

	public GameObject[] gems;
	public GameObject asteroid;

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
	}

	void Update () {
		if (asteroidCount < 40) {
			SpawnAsteroid ();
		}
	}

	void SpawnAsteroid () {
		float xPos = Random.Range (-50, 50);
		float yPos = Random.Range (-50, 50);
		Vector3 spawnPosition = new Vector3 (xPos, yPos, 0);
		SimplePool.Spawn (asteroid, spawnPosition, Quaternion.identity);
		asteroidCount += 1;
	}
}
