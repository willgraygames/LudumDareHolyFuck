using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject player;
	public float smoothSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float xPos = Mathf.Lerp (transform.position.x, player.transform.position.x, smoothSpeed * Time.deltaTime);
		float yPos = Mathf.Lerp (transform.position.y, player.transform.position.y, smoothSpeed * Time.deltaTime);
		transform.position = new Vector3 (xPos, yPos, transform.position.z);
	}
}
