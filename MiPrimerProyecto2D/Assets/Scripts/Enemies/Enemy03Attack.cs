using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy03Attack : MonoBehaviour 
{
	public bool ActiveAudio;
	public float timeBetweenBullets = 0.5f;
	public float damagePerShot = 5;		
	public float ChangeoverTime = 10;
	public float Range = 3;
	public ParticleSystem gunParticles;
	public Transform SpawnBullets;
	public Transform transformParticles;
	public Vector3 PositionParticlesRight;
	public Vector3 PositionParticlesLeft;
	public Vector3 PositionLineRanderRight;
	public Vector3 PositionLineRanderLeft;
	public GameObject LineFireFX;	
	public AudioSource ASFire;
	public bool off = false;
	//private variable
	private Animator Anim;
	private EnemyHealth Defending;
	private bool IsAttacking = false;
	private Transform PlayerPosition;
	private float isHiddenTime;
	private float isTimeAttacking;
	private float timer = 0;
	private SpriteRenderer EnemySR;
	private float effectsDisplayTime = 0.2f;
	void Awake()
	{
		Anim = GetComponent<Animator>();
		Defending = GetComponent<EnemyHealth>();		
		GameObject Player = GameObject.FindGameObjectWithTag ("Player");
		PlayerPosition = Player.transform;
		isHiddenTime = ChangeoverTime;
		isTimeAttacking = ChangeoverTime;
		EnemySR = GetComponent<SpriteRenderer> ();
		ActiveAudio = false;
	}

	void Update()
	{		
		if (off)
			return;
		
		timer += Time.deltaTime;
		if(isAttackReady() && timer >= timeBetweenBullets)
		{
			Shoot();
			float move = PlayerPosition.position.x > transform.position.x ? 1:-1;
			Flip(move);
		}

		if(timer >= timeBetweenBullets*effectsDisplayTime)
		{
			DisableEffects ();
		}
	}

	bool isAttackReady()
	{
		if(IsAttacking)
		{
			EnemyIsAttacking ();
			isHiddenTime = ChangeoverTime;
			isTimeAttacking -= Time.deltaTime;
		}
		else
		{
			EnemyIsHidden ();
			isTimeAttacking = ChangeoverTime;
			isHiddenTime -= Time.deltaTime;
		}

		if(isHiddenTime <= 0)
			IsAttacking = true;

		if(isTimeAttacking <= 0)
			IsAttacking = false;

		return IsAttacking;
	}

	private void EnemyIsHidden()
	{
		Anim.SetBool("IsHidden", true);
		Defending.armor = 1000;
	}

	private void EnemyIsAttacking()
	{		
		Anim.SetBool("IsHidden", false);
		Defending.armor = 0;
	}

	void OnTriggerEnter2D(Collider2D other)
	{        
		if(other.gameObject.tag == "Player")
		{
			IsAttacking = true;
		}
	}

	public void DisableEffects ()
	{
		LineFireFX.SetActive(false);
		gunParticles.Stop ();
	}

	void Flip(float move)
	{		
		/*Esto es un tanto largo y es porque hace muchas cosas 
		a la vez que estan relacionadas, si el enemigo se da vuelta
		tengo que cambiar de posicion y rotacion el spawn de las balas*/
		if (move > 0) {
			EnemySR.flipX = true;	
			transformParticles.localPosition = PositionParticlesRight;
			SpawnBullets.localPosition = new Vector3(0.5f, 0, 0);
			SpawnBullets.localRotation = Quaternion.AngleAxis(0, new Vector3(0,0,1));
			LineFireFX.transform.localPosition = PositionLineRanderRight;
		} 
		else
		{
			EnemySR.flipX = false;
			transformParticles.localPosition = PositionParticlesLeft;
			SpawnBullets.localPosition = new Vector3(-0.5f, 0, 0);
			SpawnBullets.localRotation = Quaternion.AngleAxis(180, new Vector3(0,1,0));			
			LineFireFX.transform.localPosition = PositionLineRanderLeft;
		}
	}

	void Shoot ()
	{
		timer = 0f;
		if(ActiveAudio)
			ASFire.Play ();
		gunParticles.Stop ();
		gunParticles.Play ();
		LineFireFX.SetActive(true);

		Vector2 origen = new Vector2(SpawnBullets.position.x, SpawnBullets.position.y);
		Vector3 dir = SpawnBullets.right;
		Vector2 direccion = new Vector2 (dir.x, dir.y);
		RaycastHit2D shootHit = Physics2D.Raycast (origen, direccion, Range);

		if (shootHit.collider != null) {
			PlayerHealth2D playerHealth = shootHit.collider.GetComponent <PlayerHealth2D> ();
			if(playerHealth != null)
			{				
				playerHealth.TakeDamage (damagePerShot);				
			}
		}
	}

}
