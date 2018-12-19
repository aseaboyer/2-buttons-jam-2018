using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleUpdater : MonoBehaviour {

	public Transform lNode;
	public Transform rNode;

	public Transform paddle;
	public LineRenderer plr; // Paddle Line Renderer

	public float moveSpeed = 0.2f;
	public float fallSpeed = 0.1f;

	// Use this for initialization
	void Start () {
		if (!lNode || !rNode || !paddle || !plr) {
			Debug.Log ("Set your paddle properties!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		bool moving = false;

		if (Input.GetButton ("left")) {


			moving = true;
		}
		if (Input.GetButton ("right")) {


			moving = false;
		}

		if (!moving) {
			// Paddles slide down!
		}

		TurnPaddle ();
	}

	public float AngleBetweenNodes () {
		return Vector2.Angle (lNode.transform.position, rNode.transform.position);
	}

	public float AverageY () {
		return 0f;
	}

	public void CenterPaddle () {
		paddle.transform.position = new Vector3(lNode.position.x + rNode.position.x, lNode.position.y + rNode.position.y ) / 2f;
	}

	public void TurnPaddle () {
		// set angle
		float a = AngleBetweenNodes ();
		Debug.Log (a);
		Quaternion currentRot = paddle.transform.rotation;
		Vector3 newRot = Vector3.zero;
		newRot.z = a * 0.5f;
		//paddle.transform.rotation = newRot;
		//paddle.transform.Rotate (newRot, Space.World);
		paddle.transform.rotation = Vector3 (0f, 0f, a);

		// position paddle
		CenterPaddle ();

		// Also update the line renderer points
	}
}
