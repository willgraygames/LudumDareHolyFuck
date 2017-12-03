using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour 
{
	public Transform target;
	public float speed;
	private float minDistance = 1f;
	private float range;

	void Start () {
		speed = 10f;
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	// Update is called once per frame
	void Update () 
	{
		range = Vector2.Distance (transform.position, target.position);
		if (range > minDistance)
		{
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		}	
	}
}

enum GemType { common, uncommon, rare, legendary }
