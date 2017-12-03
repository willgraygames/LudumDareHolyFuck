using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaster : MonoBehaviour {

	public float moveSpeed;
	public float maxSpeed;

	public GameObject cameraReference;
	public GameObject laserHousing;

	Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		HandleMovement ();
	}

	void HandleMovement () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (horizontal, vertical);
		rb2d.AddForce (movement * moveSpeed);
		rb2d.velocity = Vector2.ClampMagnitude (rb2d.velocity, maxSpeed);
	}
}