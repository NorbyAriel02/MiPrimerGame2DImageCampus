﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack02 : MonoBehaviour {
	
	public int damagePerShot = 20;
	public float timeBetweenBullets = 0.15f;
	public float range = 100f;
	public Transform SpawnBullets;
	public ParticleSystem gunParticles;
	public GameObject gunLine;

	private float timer;
	private int hit = 0;
	private int shootableMask;


	//private AudioSource gunAudio;
	//private Light gunLight;
	private float effectsDisplayTime = 0.2f;

	void Awake ()
	{
		//shootableMask = LayerMask.GetMask ("Shootable");
		//gunAudio = GetComponent<AudioSource> ();
		//gunLight = GetComponent<Light> ();
	}


	void Update ()
	{
		timer += Time.deltaTime;

		if(Input.GetKeyDown (KeyCode.LeftControl) && timer >= timeBetweenBullets)
		{
			Shoot ();
		}

		if(timer >= timeBetweenBullets * effectsDisplayTime)
		{
			DisableEffects ();
		}
	}


	public void DisableEffects ()
	{
		gunLine.SetActive(false);
		gunParticles.Stop ();
	}

	void Shoot ()
	{
		timer = 0f;

		//gunAudio.Play ();

		//gunLight.enabled = true;

		gunParticles.Stop ();
		gunParticles.Play ();


		gunLine.SetActive(true);
		//gunLine.SetPosition (0, transform.position);
		Vector2 origen = new Vector2(SpawnBullets.position.x, SpawnBullets.position.y);
		Vector3 dir = SpawnBullets.right;
		Vector2 direccion = new Vector2 (dir.x, dir.y);
		RaycastHit2D shootHit = Physics2D.Raycast (origen, direccion, range);

		if (shootHit.collider != null) {
			EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
			if(enemyHealth != null)
			{				
				enemyHealth.TakeDamage (damagePerShot);
				hit++;
			}
		}
	}
}
