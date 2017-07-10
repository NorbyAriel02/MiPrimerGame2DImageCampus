using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	/*No esta bien no es escalable en caso de que se incorporer enemigos*/
	public float armor = 0.0f;
	public float health = 100.0f;
	public GameObject gameController;
	public float TypeEnemy = 2;//he aqui el problema
	public float ScorePoints = 20;
	//variable private
	private HUDcontroller hud;
	private DroppedObject Drop;
	private EnemyAnimController anim;

	void Awake()
	{		
		hud = gameController.GetComponent<HUDcontroller>();
		Drop = GetComponent<DroppedObject> ();
		anim = GetComponent<EnemyAnimController> ();
	}

	public void TakeDamage(float danger)
	{
		
		/*hace daño si la armadura es menos al ataque*/
		MakeDamage(danger);

		if (this.health > 0) {
			anim.SetHit ();
		}
		else 
		{
			anim.SetDie ();
			DisableEnemy();			
			if(Drop != null)
				Drop.DropObject ();			
		}
	}

	public void destroy()
	{
		Destroy (gameObject);
	}

	private void MakeDamage(float danger)
	{
		if(danger > armor)
		{
			health -= danger;	
			hud.SetScore(hud.GetScore()+ScorePoints);
		}
	}

	private void DisableEnemy()
	{		
		if(TypeEnemy == 1)
		{
			gameObject.GetComponent<EnemyRound> ().off = true;
			gameObject.GetComponent<EnemyAttack> ().off = true;
		}
		else if(TypeEnemy == 2)
		{
			gameObject.GetComponent<Enemy02Move> ().off = true;
			gameObject.GetComponent<Enemy02Attack> ().off = true;
		}
		else if(TypeEnemy == 3)
		{
			
		}
	}
}
