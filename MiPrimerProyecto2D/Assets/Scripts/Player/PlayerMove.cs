using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public float Speed;
	public float powerJump;
	public Transform SpawnProjectile;
	public Transform SpawnBullets;//cuando el player hace el flip tengo que cambiar la posicion del spawn
	public Transform transformParticles;
	public Vector3 PositionParticlesRight;
	public Vector3 PositionParticlesLeft;
	//Variables privadas
	private Rigidbody2D rbPlayer;
	private SpriteRenderer PlayerSR;
	private bool IsJump;
	private Animator AnimPlayer;

	void Awake()
	{
		AnimPlayer = GetComponent<Animator> ();
		rbPlayer = GetComponent<Rigidbody2D> ();
		PlayerSR = GetComponent<SpriteRenderer> ();
		IsJump = false;
	}

	void Update () {
		


	}

	void FixedUpdate()
	{
		float move = Input.GetAxis ("Horizontal");
		float jump = Input.GetKeyDown (KeyCode.Space) ? 1 : 0; 

		MovedPlayer(move, jump);
		AnimatorPlayer (move, jump);
		Flip (move);
	}

	void AnimatorPlayer(float move, float jump)
	{
		if (move != 0 && jump == 0) {
			//Debug.Log ("Esta caminando");
			AnimPlayer.SetBool("IsWalking", true);
		} else if (jump != 0) {
			AnimPlayer.SetTrigger ("IsJumping");
		}
		else {
			//Debug.Log ("No camina "+ jump);
			AnimPlayer.SetBool("IsWalking", false);
		}
	}

	void MovedPlayer(float move, float jump)
	{
		Vector2 vel = Vector2.zero;
		vel = rbPlayer.velocity;

		if(!IsJump)
			vel.x = move * Speed * Time.fixedDeltaTime;

		if(jump > 0 && !IsJump)
			vel.y = powerJump;

		rbPlayer.velocity = vel;
	}

	void Flip(float move)
	{
		if (move == 0)
			return;
		
		if (PlayerSR.flipX && move > 0) {
			PlayerSR.flipX = false;	
			transformParticles.localPosition = PositionParticlesRight;
			SpawnBullets.localPosition = new Vector3 (0.7f, 0, 0);
			SpawnBullets.localRotation = Quaternion.AngleAxis(0, new Vector3(0,0,1));
			SpawnProjectile.localPosition = new Vector3 (0.8f, 0, 0);
			SpawnProjectile.localRotation = Quaternion.AngleAxis(20, new Vector3(0,0,1));
		} else if(!PlayerSR.flipX && move < 0)  {
			PlayerSR.flipX = true;
			transformParticles.localPosition = PositionParticlesLeft;
			SpawnBullets.localPosition = new Vector3 (-0.7f, 0, 0);
			SpawnBullets.localRotation = Quaternion.AngleAxis(180, new Vector3(0,1,0));
			SpawnProjectile.localPosition = new Vector3 (-0.8f, 0, 0);
			SpawnProjectile.localRotation = Quaternion.AngleAxis(180, new Vector3(0.18f,1,0));
		}
	}

	/*
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "ground" && other.contacts [0].normal.y == 1)
			IsJump = false;
	}*/

	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.tag == "ground" && other.contacts [0].normal.y == 1)
			IsJump = false;
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.tag == "ground")
			IsJump = true;
	}
}
