using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02Move : MonoBehaviour {
	public float Speed = 2;
	public bool off = false;
	// Use this for initialization
	private Rigidbody2D EnemyRB;
	void Start () {
		EnemyRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (off) {
			EnemyRB.velocity = Vector2.zero;
			return; 
		}
		
		Move ();
	}

	void Move()
	{
		Vector2 vel = Vector2.zero;
		vel = EnemyRB.velocity;

		vel.x = Speed * Time.fixedDeltaTime;

		EnemyRB.velocity = vel;
	}	
}
