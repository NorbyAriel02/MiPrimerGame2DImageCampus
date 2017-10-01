using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEnemy03 : MonoBehaviour {
	public GameObject enemy;
	public bool valueAudio = true;
	private Enemy03Attack attack;

	void Awake()
	{
		attack = enemy.GetComponentInParent<Enemy03Attack> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{        
		if(other.gameObject.tag == "Player")
		{
			attack.ActiveAudio = valueAudio;
		}
	}
}
