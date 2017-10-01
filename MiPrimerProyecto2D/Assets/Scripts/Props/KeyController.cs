using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {
	public AudioSource ASHasKey;
	private PlayerInventory Inventory;
	void Awake () {
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
		Inventory = go.GetComponent<PlayerInventory> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/*
	void OnTriggerEnter2D(Collider2D other)
	{        
		if(other.gameObject.tag == "Player")
		{			
			ASHasKey.Play ();
			Inventory.HasKey = true;
			Inventory.SetElement ("key", 1);
			Destroy (gameObject, ASHasKey.clip.length);
		}
	}*/

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			ASHasKey.Play ();
			Inventory.HasKey = true;
			Inventory.SetElement ("key", 1);
			Destroy (gameObject, ASHasKey.clip.length);
		}
	}
}
