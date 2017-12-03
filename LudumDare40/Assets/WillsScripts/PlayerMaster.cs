using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaster : MonoBehaviour {

	public static PlayerMaster Instance { get; protected set; }

	public float moveSpeed;
	public float maxSpeed;
	public int health;

	public GameObject cameraReference;
	public GameObject laserHousing;

	Rigidbody2D rb2d;

	void Awake () {
		if (Instance != null) {
			print ("There should only be on player");
		} else {
			Instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
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

	void OnCollisionEnter2D(Collision2D collide)
	{
		if (collide.gameObject.tag == "PurpleGem")
		{
			GameManager.Instance.gemCount += 1;
			Destroy (collide.gameObject);
		}
		if (collide.gameObject.tag == "PinkGem")
		{
			GameManager.Instance.gemCount += 2;
			Destroy (collide.gameObject);
		}
		if (collide.gameObject.tag == "FuschiaGem")
		{
			GameManager.Instance.gemCount += 5;
			Destroy (collide.gameObject);
		}
		if (collide.gameObject.tag == "TurquoiseGem")
		{
			GameManager.Instance.gemCount += 7;
			Destroy (collide.gameObject);
		}
	}
}