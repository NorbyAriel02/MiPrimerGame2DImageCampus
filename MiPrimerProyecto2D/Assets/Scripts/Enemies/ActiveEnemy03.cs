using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEnemy03 : MonoBehaviour {
	private Enemy03Attack attack;

	void Awake()
	{
		attack = GetComponentInParent<Enemy03Attack> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{        
		if(other.gameObject.tag == "Player")
		{
			attack.ActiveAudio = true;
		}
	}


	void OnTriggerExit2D(Collider2D other)
	{        
		if(other.gameObject.tag == "Player")
		{
			attack.ActiveAudio = false;
		}
	}
}
