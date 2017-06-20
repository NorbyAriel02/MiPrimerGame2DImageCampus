using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {
	public Sprite DoorOpen;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			PlayerInventory inventory = other.gameObject.GetComponent<PlayerInventory> ();
			if (inventory.HasKey) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = DoorOpen;
				gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
				this.enabled = false;	
			}
		}
	}
}
