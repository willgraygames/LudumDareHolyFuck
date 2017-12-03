using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

	public int laserDamage;
	public GameObject hitParticle;
	public GameObject hitLight;

	bool laserOvercharge;

	LineRenderer myLine;

	// Use this for initialization
	void Start () {
		myLine = GetComponent<LineRenderer> ();
		hitParticle.SetActive (false);
		hitLight.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3 (0, 0, Mathf.Atan2 (Input.GetAxis ("RightV"), Input.GetAxis ("RightH")) * -180 / Mathf.PI);
		if (Input.GetAxis ("Overcharge") > 0) {
			laserOvercharge = true;
		} else {
			laserOvercharge = false;
		}
		HandleLaser ();
		if (hitParticle.activeInHierarchy == true) {
			hitParticle.transform.LookAt (transform.position);
		}
	}

	void HandleLaser () {
		if (Input.GetAxis ("RightV") == 0 && Input.GetAxis ("RightH") == 0) {
			myLine.enabled = false;
			hitParticle.SetActive (false);
			hitLight.SetActive (false);
		} else {
			RaycastHit2D hit = Physics2D.Raycast (transform.TransformPoint(Vector3.zero), transform.TransformDirection(Vector3.right));
			myLine.enabled = true;
			myLine.SetPosition (0, new Vector3(0,0,0));
			if (laserOvercharge == true && GameManager.Instance.gemCount > 0) {
				myLine.startWidth = 30;
				myLine.endWidth = 30;
				myLine.startColor = Color.red;
				myLine.endColor = Color.red;
				hitParticle.gameObject.transform.localScale = new Vector3 (10, 10, 10);
				var main = hitParticle.GetComponent<ParticleSystem> ().main;
				main.startColor = Color.red;
				hitLight.transform.localScale = new Vector3 (10, 10, 10);
				laserDamage = 40;
				GameManager.Instance.gemCount -= 1;
			} else {
				myLine.startWidth = 1;
				myLine.endWidth = 1;
				myLine.startColor = Color.cyan;
				myLine.endColor = Color.cyan;
				hitParticle.gameObject.transform.localScale = new Vector3 (1, 1, 1);
				var main = hitParticle.GetComponent<ParticleSystem> ().main;
				main.startColor = Color.cyan;
				hitLight.transform.localScale = new Vector3 (1, 1, 1);
				laserDamage = 4;
			}
			if (hit.collider != null && hit.collider.isTrigger == false) {
				myLine.SetPosition (1, new Vector2(hit.distance, 0));
				hitParticle.SetActive (true);
				hitLight.SetActive (true);
				hitParticle.transform.position = hit.point;
				hitLight.transform.position = hit.point;
				if (hit.collider.gameObject.tag == "Asteroid") {
					hit.collider.gameObject.GetComponent<Asteroid> ().health -= laserDamage;
				} else if (hit.collider.gameObject.tag == "Enemy") {
					hit.collider.gameObject.GetComponent<Enemy> ().health -= laserDamage;
				}
			} else {
				myLine.SetPosition(1, new Vector2 (70, 0));
				hitParticle.SetActive (false);
				hitLight.SetActive (false);
			}
		}

	}
}