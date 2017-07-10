using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02Attack : MonoBehaviour {
	public float timeBetweenBullets = 2.5f;
	public float damagePerShot = 5;		
	public float range = 3;
	public Transform SpawnBullets;//cuando el player hace el flip tengo que cambiar la posicion del spawn
	public ParticleSystem Particles;
	public GameObject LineFireFX;	
	public AudioSource ASFire;
	public bool off = false;
	//private variable
	private Animator anim;
	private float timer = 0;
	private Transform PlayerPosition;
	private float effectsDisplayTime = 0.2f;

	void Awake()
	{
		anim = GetComponent<Animator>();
		GameObject Player = GameObject.FindGameObjectWithTag ("Player");
		PlayerPosition = Player.transform;
	}

	void Update()
	{
		if (off)
			return;

		timer += Time.deltaTime;
		if(timer >= timeBetweenBullets)
		{
			Shoot();			
		}

		if(timer >= effectsDisplayTime)
		{
			DisableEffects ();
		}
	}

	public void DisableEffects ()
	{
		LineFireFX.SetActive(false);
		Particles.Stop ();
	}	

	void Shoot ()
	{
		timer = 0f;
		if(!ASFire.isPlaying)
			ASFire.Play ();
		
		Particles.Stop ();
		Particles.Play ();
		LineFireFX.SetActive(true);

		Vector2 origen = new Vector2(SpawnBullets.position.x, SpawnBullets.position.y);
		Vector3 dir = SpawnBullets.right;
		Vector2 direccion = new Vector2 (dir.x, dir.y);
		RaycastHit2D shootHit = Physics2D.Raycast (origen, direccion, range);

		if (shootHit.collider != null) {
			PlayerHealth2D playerHealth = shootHit.collider.GetComponent <PlayerHealth2D> ();
			if(playerHealth != null)
			{				
				playerHealth.TakeDamage (damagePerShot);				
			}
		}
	}	
}
