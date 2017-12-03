using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance { get; protected set; }

	public 

	void Awake () {
		if (Instance != null) {
			print ("There should only be one Game Manager");
		} else {
			Instance = this;
		}
	}

	void Update () {
		
	}
}
