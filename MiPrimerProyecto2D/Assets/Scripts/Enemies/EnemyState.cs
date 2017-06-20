using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour {
	private EnemyRound Round;
	private EnemyAttack Attack;
	void Awake()
	{
		Round = GetComponent<EnemyRound> ();
		Attack = GetComponent<EnemyAttack> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			Round.enabled = false;
			Attack.enabled = true;
		}			
	}
}
