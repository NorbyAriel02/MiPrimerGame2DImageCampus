using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

	private float timer;
	void Start () {
		timer = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0)
			SceneManager.LoadScene ("Nivel01");
	}
}
