using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {
	private PlayerInventory Inventory;
	// Use this for initialization
	void Awake () {
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
		Inventory = go.GetComponent<PlayerInventory> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			Destroy (gameObject);
			Inventory.HasKey = true;
			Inventory.SetElement ("key", 1);
		}
	}
}
