using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedObject : MonoBehaviour {
	public GameObject prop;
	private bool alreadyDrop = false;
	void Update () {
		
	}
	public void DropObject()
	{
		if (!alreadyDrop) {
			Instantiate (prop, gameObject.transform.position, Quaternion.identity);
			alreadyDrop = true;
		}
	}
}