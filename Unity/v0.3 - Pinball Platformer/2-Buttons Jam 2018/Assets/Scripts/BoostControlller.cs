using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostControlller : MonoBehaviour {

	public float boostStrength = 100f;
	public float spinSpeed = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate () {
		Spin ();
	}

	void OnTriggerEnter2D (Collider2D o) {
		if (o.transform.tag == "Player") {
			Rigidbody2D rb = o.GetComponent<Rigidbody2D> ();
			Vector2 up = this.transform.up;

			if (rb) {
				rb.AddForce (up * boostStrength, ForceMode2D.Impulse);
			}
		}
	}

	public void Spin () {
		transform.Rotate (Vector2.up * spinSpeed);
	}
}
