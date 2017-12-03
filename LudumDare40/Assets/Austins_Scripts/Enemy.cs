using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	Transform target;
	public float speed = 2f;
	private float minDistance = 1f;
	private float range;
	public int damage;

	public int health;
	public int maxHealth;
	bool canMove = true;

	void OnEnable () {
		health = maxHealth;
	}

	void Update()
	{
		target = PlayerMaster.Instance.gameObject.transform;
		if (canMove ==true)
		{
			//Debug.Log ("inside of if");
			Move ();
		}
		if (health <= 0) {
			GameManager.Instance.enemyCount -= 1;
			SimplePool.Despawn (this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collide)
	{
		if (collide.collider.gameObject.tag == "Player")
		{
			Debug.Log ("Hit Player");
			canMove = false;
			StartCoroutine (TimePass ());
			GameManager.Instance.gemCount -= 10;
			collide.gameObject.GetComponent<PlayerMaster> ().health -= damage;
		}
	}

	void Move()
	{
		Quaternion rotation = Quaternion.LookRotation (target.transform.position - transform.position, transform.TransformDirection (Vector3.up));
		transform.rotation = new Quaternion (0, 0, rotation.z, rotation.w);
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
