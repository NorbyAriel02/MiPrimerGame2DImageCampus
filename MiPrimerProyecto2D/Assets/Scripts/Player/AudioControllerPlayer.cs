using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerPlayer : MonoBehaviour {
	public Animator anim;//lo uso para saber en que momentos esta reproduciendo tal animacion
	public AudioSource AudioSourcePlayer;
	public AudioClip WalkClip;
	public AudioClip JumpClip;
	public AudioClip FireClip;
	public float AudioSpeedWalk;
	// Use this for initialization
	private float timerWalk;
	private float timerShoot;
	private float timeBetweenBullets;
	private PlayerMove playerMove;
	void Awake()
	{
		timeBetweenBullets = GetComponent<PlayerAttack02> ().timeBetweenBullets;
		playerMove = GetComponent<PlayerMove> ();
		timerWalk = AudioSpeedWalk;
	}

	// Update is called once per frame
	void Update () {
		timerWalk -= Time.deltaTime;
		if (timerWalk <= 0 && anim.GetBool ("IsWalking") && !AudioSourcePlayer.isPlaying) {
			AudioSourcePlayer.clip = WalkClip;
			AudioSourcePlayer.Play ();
			timerWalk = AudioSpeedWalk;
		}

		if (anim.GetBool ("IsJumping") ) {
			AudioSourcePlayer.clip = JumpClip;
			if(!AudioSourcePlayer.isPlaying && !playerMove.IsJump)
				AudioSourcePlayer.Play ();
		}

		timerShoot += Time.deltaTime;

		if(Input.GetKeyDown (KeyCode.LeftControl) && timerShoot >= timeBetweenBullets)
		{
			AudioSourcePlayer.clip = FireClip;
			AudioSourcePlayer.Play ();
			timerShoot = 0;
		}
	}
}
