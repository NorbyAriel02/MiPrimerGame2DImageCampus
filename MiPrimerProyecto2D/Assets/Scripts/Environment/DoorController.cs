using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {
	public Sprite DoorOpen;
	public AudioSource doorOpenAudio;
	private PlayerInventory Inventory;

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
			if (Inventory.GetElemnt("key") > 0) {
				gameObject.GetComponent<SpriteRenderer> ().sprite = DoorOpen;
				gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
				Inventory.SetElement ("key", -1);
				this.enabled = false;	
				doorOpenAudio.Play ();
			}
		}
	}
}
