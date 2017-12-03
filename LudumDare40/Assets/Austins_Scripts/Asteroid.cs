using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Asteroid : MonoBehaviour 
{
	public float speed;
	public float health; 
	public int numOfGems;

	public GameObject[]GemArray = new GameObject[4]; 

	Rigidbody2D mybody;

	void Awake()
	{
		health = Random.Range(50f, 200f);
		numOfGems = Mathf.FloorToInt (health / 50);
		mybody =GetComponent<Rigidbody2D>();
		Vector2 shitbird = new Vector2 (Random.Range (-10f, 10f), Random.Range (-10f, 10f));
		mybody.AddForce (shitbird* speed, ForceMode2D.Impulse) ;
	}

	void Update()
	{
		if (health <= 0)
		{
				for (int j=0; j< numOfGems; j++)
				{
					int randomValue = Random.Range (0, 100);
					if (randomValue <=50)
					{
					Instantiate (GemArray [0], transform.position, transform.rotation);
					}
					if (randomValue>= 51&& randomValue<=75)
					{
					Instantiate(GemArray[1], transform.position, transform.rotation);
					}
					if (randomValue>= 76&& randomValue<=90)
					{
					Instantiate(GemArray[2], transform.position, transform.rotation);
					}
					if (randomValue>= 91&& randomValue<=100)
					{
					Instantiate(GemArray[3], transform.position, transform.rotation);
					}
				}
			Destroy (this.gameObject);
		}
	}
}
