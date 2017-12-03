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



	void Update()
	{

		transform.LookAt (target);
		range = Vector2.Distance (transform.position, target.position);
		if (range > minDistance)
		{
			
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		}
	}

	void OnCollisionEnter2D(Collision2D collide)
	{
		if (collide.collider.gameObject.tag == "Player")
		{
			Debug.Log ("Hit Player");
			transform.position = new Vector2 (transform.position.x, transform.position.y);
		}
	}

}
