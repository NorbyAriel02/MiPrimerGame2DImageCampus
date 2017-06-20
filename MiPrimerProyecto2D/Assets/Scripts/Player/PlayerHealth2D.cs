﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth2D : MonoBehaviour {
	public float Health = 100;	
	public GameObject gameController;
	//variable private
	//private Animator Anim;
	private HUDcontroller hud;
	private GameController game;
	void Awake()
	{
		//Anim = GetComponent<Animator> ();
		hud = gameController.GetComponent<HUDcontroller>();
		hud.SetHealth(Health/100);
		game = gameController.GetComponent<GameController> ();
	}

	public void TakeDamage(float danger)
	{
		Health -= danger;
		hud.SetHealth(Health/100);
		if (Health > 0) {
			//Anim.SetTrigger ("IsHit");
		}
		else 
		{
			//Anim.SetTrigger ("IsDie");
			//gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
			gameObject.GetComponent<PlayerMove> ().enabled = false;
			game.gameOver ();
		}
	}
}
