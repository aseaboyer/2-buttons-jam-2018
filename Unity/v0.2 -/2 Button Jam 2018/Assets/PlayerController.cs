using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Animator animator;

	public bool actionCooldown = false;
	public float cooldownTime = 1f;

	public float fuelMax = 100f;
	public float fuelCurrent = 100;
	public float fuelIncreaseRate = 1f;

	public float moveSpeed = 1f;
	public float boostSpeed = 10f;
	public float strafeSpeed = 1f;

	public float boostChargeTime = 1f;
	public float startedBoosting = 0f;
	public bool isBoosting = false;

	// Use this for initialization
	void Start () {
		fuelCurrent = fuelMax;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton ("Left") && Input.GetButton ("Right")) {
			// Boosting

		} else { // check for regular movement
			if (Input.GetButton ("Left")) {
				//Debug.Log ("Strafe left");
				Strafe (-1);

			} else if (Input.GetButton ("Right")) {
				//Debug.Log ("Strafe right");
				Strafe (1);

			}

		}
	}

	public void Strafe (float value) {
		Vector3 pos = transform.position;
		pos.x += (value * Time.deltaTime);
		transform.position = pos;
	}

	public void UpdateFuel () {
		
	}
}
