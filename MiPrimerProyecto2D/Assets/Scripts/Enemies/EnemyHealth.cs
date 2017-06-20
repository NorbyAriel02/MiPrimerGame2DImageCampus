using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	public float health = 100;
	public GameObject gameController;
	//variable private
	private HUDcontroller hud;
	private Animator Anim;
	void Awake()
	{
		Anim = GetComponent<Animator> ();
		hud = gameController.GetComponent<HUDcontroller>();
	}

	public void TakeDamage(float danger)
	{
		health -= danger;
		hud.SetScore(hud.GetScore()+20);
		if (this.health > 0) {
			//Anim.SetTrigger ("IsHit");
		}
		else 
		{
			//Anim.SetTrigger ("IsDie");
			//gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
			gameObject.GetComponent<EnemyRound> ().enabled = false;
			gameObject.GetComponent<EnemyAttack> ().enabled = false;
			Destroy (gameObject, 3.0f);
		}
	}
}
