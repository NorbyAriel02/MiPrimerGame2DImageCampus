using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
	public float Bullets = 3;
	public float TimeBetweenShots;
	public string PlayerNameKey = "Test";
	public string ScoreKey = "ScoreKey";
	public string BulletsKey = "BulletsKey";
	public GameObject gameController;
	public GameObject Projectile;
	public Transform SpawnProjectile;
	//private varible
	private HUDcontroller hud;
	void Awake()
	{
		hud = gameController.GetComponent<HUDcontroller>();
		hud.SetBullets(Bullets);
		hud.SetScore(0);
	}

	void Update()
	{
		TimeBetweenShots -= Time.deltaTime;
		if(Input.GetKeyDown (KeyCode.LeftControl) && Bullets > 0 && TimeBetweenShots < 0)
			Fire();
	}

	void Fire()
	{
		Instantiate (Projectile, SpawnProjectile.position, SpawnProjectile.rotation);
		Bullets--;
		hud.SetBullets(Bullets);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Armor") 
		{
			Bullets += other.gameObject.GetComponent<ArmorPack> ().Bullets;
			hud.SetBullets(Bullets);
			Destroy (other.gameObject);
		}
	}
}
