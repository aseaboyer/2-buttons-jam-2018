using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform tracking;

	public Vector3 offset;

	// Use this for initialization
	void Start () {
		// find the player, the only thing we will track!
		tracking = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		FollowTarget ();
	}

	private void FollowTarget () {
		if (tracking) {
			transform.position = (tracking.transform.position + offset);
		}
	}
}
