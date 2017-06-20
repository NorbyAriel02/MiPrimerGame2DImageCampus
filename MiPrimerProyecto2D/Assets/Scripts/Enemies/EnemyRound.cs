using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRound : MonoBehaviour {
	public float rangeRound;
	public float resetRound;
	public float SmoothLerp;

	//Variables Privadas
	public Transform SpawnProjectile;
	private Vector3 FromPos;
	private Vector3 ToPos;
	private Vector3 FinalPos;
	private float timer;
	private bool flip = false;
	private Animator EnemyAnim;
	private bool HastaArreglarAnim = true;
	private EnemyFlip enemyFlip;
	void Awake()
	{
		FromPos = transform.position;

		ToPos = transform.position + new Vector3(rangeRound, 0, 0);

		FinalPos = ToPos;

		timer = 0.0f;
		//EnemyAnim = GetComponentInChildren<Animator> ();	
		enemyFlip = GetComponent<EnemyFlip> ();
	}

	void Update () 
	{
		move ();
	}

	void move()
	{
		timer += Time.deltaTime;

		if (HastaArreglarAnim /*EnemyAnim.GetBool ("IsWalking")*/) {			
			transform.position = Vector3.Lerp (FromPos, ToPos, timer * SmoothLerp);
		} 

		if(flip)
		{
			flip = false;
			enemyFlip.FlipInRound ();
		}

		if (transform.position == ToPos) 
		{
			HastaArreglarAnim = false;
			//EnemyAnim.SetBool ("IsWalking", false);
		}

		if (timer >= resetRound) {
			flip = true;

			//EnemyAnim.SetBool ("IsWalking", true);
			HastaArreglarAnim = true;

			FinalPos = FromPos;
			FromPos = ToPos;
			ToPos = FinalPos;

			timer = 0.0f;

		}
	}
}
