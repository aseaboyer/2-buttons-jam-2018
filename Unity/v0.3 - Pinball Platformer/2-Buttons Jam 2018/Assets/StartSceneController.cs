using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour {

	public string nextLevel = "Level 1";
	public float levelChangeDelay = 1f;

	public void PlayerJumped () {
		Invoke ("StartLevel", levelChangeDelay);
	}

	public void StartLevel () {
		SceneManager.LoadScene (nextLevel);
	}
}
