using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPack : MonoBehaviour {
	public AudioSource ASBombsPack;
	public float Bullets = 3;


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{			
			ASBombsPack.Play ();
			Destroy (gameObject, ASBombsPack.clip.length);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{        
		if(other.gameObject.tag == "Player")
		{			
			ASBombsPack.Play ();
			Destroy (gameObject, ASBombsPack.clip.length);
		}

		if(other.gameObject.tag == "ground")
		{			
			gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
			gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
		}
	}
}
