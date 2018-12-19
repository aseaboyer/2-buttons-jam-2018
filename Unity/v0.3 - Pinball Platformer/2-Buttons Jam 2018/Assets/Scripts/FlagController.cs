using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagController : MonoBehaviour {

	public string nextLevelName;

	public GameObject endingMessage;
	public float endDelay = 3f;

	// Use this for initialization
	void Start () {
		if (endingMessage) {
			endingMessage.SetActive (false);
		}
	}

	void OnTriggerEnter2D (Collider2D o) {
		if (endingMessage && endDelay > 0) {
			endingMessage.SetActive (true);
			Invoke ("EndLevel", endDelay);
		} else {
			EndLevel ();
		}
	}

	private void EndLevel () {
		Debug.Log ("Send the player to level " + nextLevelName);
		SceneManager.LoadScene (nextLevelName);
	}
}
