using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
	public float Force = 10.0f;
	public float powerExplosion;
	public float radiusExplosion;
	public float damagePerShot = 50;
	public GameObject ParticleExplosion;
	public AudioSource AudioSourceExplosion;
	public SpriteRenderer SRGrenade;
	public float timer = 2.0f;
	//Private variable


	void Awake()
	{		
		GetComponent<Rigidbody2D> ().AddForce (gameObject.transform.right * Force);
	}

	void Update()
	{
		timer -= Time.deltaTime;
		if (timer <= 0)
			Explision ();
	}

	void Explision()
	{
		Instantiate (ParticleExplosion, transform.position, Quaternion.identity);
		Vector2 explosionPos = transform.position;

		Collider2D[] colliders = Physics2D.OverlapCircleAll (explosionPos, radiusExplosion);
		foreach (Collider2D hit in colliders) {	
			if (hit.isTrigger || hit.tag == "Grenade")
				continue;
			
			Rigidbody2D rb = hit.GetComponent<Rigidbody2D> ();
			EnemyHealth enemyHealth = hit.GetComponent<EnemyHealth> ();//shootHit.collider.GetComponent <EnemyHealth> ();
			PlayerHealth2D playerHealth = hit.GetComponent<PlayerHealth2D>();

			if (rb != null)
				rb.AddForce (hit.transform.right*powerExplosion);
			
			if(enemyHealth != null)
				enemyHealth.TakeDamage (damagePerShot);
			
			if (playerHealth != null)
				playerHealth.TakeDamage (damagePerShot);

			SRGrenade.sprite = null;
			AudioSourceExplosion.Play ();
		}

		Destroy (gameObject);
		this.enabled = false;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player")
			Explision ();			
	}
}
