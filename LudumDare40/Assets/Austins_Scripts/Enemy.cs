using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	public Transform target;
	public float speed = 2f;
	private float minDistance = 1f;
	private float range;

	public int health;
	bool canMove = true;

	void Update()
	{
		if (canMove ==true)
		{
			//Debug.Log ("inside of if");
			Move ();
		}
	}

	void OnCollisionEnter2D(Collision2D collide)
	{
		if (collide.collider.gameObject.tag == "Player")
		{
			Debug.Log ("Hit Player");
			canMove = false;
			StartCoroutine (TimePass ());
			collide.gameObject.GetComponent<Player> ().GemCount = collide.gameObject.GetComponent<Player> ().GemCount - 2;
		}
	}

	void Move()
	{
		//transform.LookAt (target); //turned on it does not print the Debug or "make contact"
		range = Vector2.Distance (transform.position, target.position);
		if (range > minDistance)
		{
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		}
	}

	IEnumerator TimePass()
	{
		Debug.Log ("in TimePass");
		yield return new WaitForSeconds (2f);
		canMove = true;
	}

}
