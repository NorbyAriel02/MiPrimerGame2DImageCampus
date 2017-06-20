﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	// Use this for initialization
	void Start () {
		//GameObject Player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void gameOver()
	{
		SceneManager.LoadScene ("GameOver");
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
			SceneManager.LoadScene ("Win");
	}
}