using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 1f;
	public float inputSpeed = 0f;
	public bool bothKeysDown = false;

	public float jumpForce = 5f;

	public float chargeTime = 0f;
	public float castTime = 3f;
	public float coolDown = 3f;

	public AudioClip jumpSound;

	public Rigidbody2D rb;
	public Animator animator;
	public AudioSource audioSource;
	public GameObject gameController;

	// Use this for initialization
	void Start () {
		if (!rb) {
			rb = GetComponent<Rigidbody2D> ();
		}
		if (!animator) {
			animator = GetComponent<Animator> ();
		}
		if (!audioSource) {
			audioSource = GetComponent<AudioSource> ();
		}

		if (!gameController) {
			gameController = GameObject.FindGameObjectWithTag ("GameController");
		}
	}
	
	// Update is called once per frame
	void Update () {
		inputSpeed = Input.GetAxisRaw ("Horizontal");

		if (inputSpeed != 0f) {
			Move (inputSpeed * moveSpeed * Time.deltaTime);
		}

		if (Input.GetButton ("Left") && Input.GetButton ("Right")) {
			bothKeysDown = true;
			chargeTime += (Time.deltaTime);

		} else {
			if (bothKeysDown && chargeTime >= castTime) {
				Jump ();
			}

			bothKeysDown = false;
			chargeTime = 0;
		}

		if (animator) {
			animator.SetFloat ("ChargeTime", chargeTime);
		}
	}

	public void Move (float m) {
		if (rb) {
			rb.AddForce (m * Vector2.right, ForceMode2D.Force);
		}
	}

	public void Jump () {
		if (rb) {
			rb.AddForce (jumpForce * Vector2.up, ForceMode2D.Impulse);

			if (audioSource) {
				audioSource.PlayOneShot (jumpSound);
			}
		}

		if (gameController) {
			gameController.BroadcastMessage ("PlayerJumped");
		}
	}
}
