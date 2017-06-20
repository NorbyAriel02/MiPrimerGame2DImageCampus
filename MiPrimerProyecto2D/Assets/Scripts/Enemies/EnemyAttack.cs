using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
	
	public GameObject Projectile;
	//Esto tengo que obtenerlo por un find 
	public Transform SpawnProjectile;
	public float moveSpeed;
	public float rotationSpeed;
	public float timer;
	public float AttackDistance = 15;
	public float timeBetweenBullets = 2;
	public bool off = false;
	//Private Variables
	private SpriteRenderer EnemySR;
	private GameObject Player;
	private Transform target;
	private EnemyFlip enemyFlip;

	void Awake()
	{
		Player = GameObject.FindGameObjectWithTag ("Player");
		target = Player.transform;
		EnemySR = GetComponent<SpriteRenderer> ();
		enemyFlip = GetComponent<EnemyFlip> ();
		//gameObject.transform.LookAt (Player.transform);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (off)
			return;

		timer -= Time.deltaTime;
		Vector3 dir = target.position - transform.position;
		dir.z = 0.0f;
		if (dir != Vector3.zero) {			
			float move = target.position.x > transform.position.x ? 1:-1;
			enemyFlip.FlipInAttack (move);
		}

		if (Vector3.Distance (target.position, transform.position) > 3) {
			Vector3 Direction = (target.position - transform.position).normalized;
			Vector3 NewDirection = new Vector3 (Direction.x, 0, 0);
			transform.position += NewDirection * moveSpeed * Time.deltaTime;
		}

		if (Vector3.Distance (target.position, transform.position) < AttackDistance && timer < 0)
			Fire ();
		
	}

	void Flip(float move)
	{
		if (move == 0)
			return;

		if (EnemySR.flipX && move > 0) {
			EnemySR.flipX = false;	
			SpawnProjectile.localPosition = new Vector3 (1, 0, 0);
			SpawnProjectile.localRotation = Quaternion.AngleAxis(20, new Vector3(0,0,1));
		} else if(!EnemySR.flipX && move < 0)  {
			EnemySR.flipX = true;
			SpawnProjectile.localPosition = new Vector3 (-1, 0, 0);
			SpawnProjectile.localRotation = Quaternion.AngleAxis(180, new Vector3(0.18f,1,0));
		}
	}

	void Fire()
	{
		timer = timeBetweenBullets;
		Instantiate (Projectile, SpawnProjectile.position, SpawnProjectile.rotation);
	}
}
