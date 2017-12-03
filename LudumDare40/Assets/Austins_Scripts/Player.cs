using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	public int GemCount=0;




	void OnCollisionEnter2D(Collision2D collide)
	{
		if (collide.collider.gameObject.tag == "PurpleGem")
		{
			GemCount=GemCount+1;
			Destroy (collide.gameObject);
		}
		if (collide.collider.gameObject.tag == "PinkGem")
		{
			GemCount=GemCount+2;
			Destroy (collide.gameObject);
		}
		if (collide.collider.gameObject.tag == "FuschiaGem")
		{
			GemCount=GemCount+5;
			Destroy (collide.gameObject);
		}
		if (collide.collider.gameObject.tag == "TurquoiseGem")
		{
			GemCount=GemCount+7;
			Destroy (collide.gameObject);
		}
	
	}




}
