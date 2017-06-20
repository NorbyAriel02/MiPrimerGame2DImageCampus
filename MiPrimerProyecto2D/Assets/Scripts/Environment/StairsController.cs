using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsController : MonoBehaviour {
	public float speed = 0;
	public float speedHorizontal = 0;
	public Vector3 FromPos;
	public Vector3 ToPos;
	public Vector3 FinalPos;
	private float stay = 0;
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.UpArrow)) {
			Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D> ();
			float x = Input.GetAxis("Horizontal");

			rb.velocity = new Vector3 (x, 2, 0);
		}
	}
	/*
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
			speed = 0;

		}
	}*/
}
