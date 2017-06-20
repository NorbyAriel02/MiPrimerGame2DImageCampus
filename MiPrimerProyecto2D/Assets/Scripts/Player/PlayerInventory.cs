using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
	public bool HasKey = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "key") {
			Destroy (other.gameObject);
			HasKey = true;
		}
	}

}
