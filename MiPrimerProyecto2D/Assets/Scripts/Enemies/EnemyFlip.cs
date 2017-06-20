using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour {
	private SpriteRenderer EnemySR;
	public Transform SpawnProjectile;

	void Awake()
	{
		EnemySR = GetComponent<SpriteRenderer> ();
	}

	public void FlipInAttack(float move)
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

	public void FlipInRound()
	{
		if (EnemySR.flipX) {
			EnemySR.flipX = false;	
			SpawnProjectile.localPosition = new Vector3 (1, 0, 0);
			SpawnProjectile.localRotation = Quaternion.AngleAxis(20, new Vector3(0,0,1));
		} else if(!EnemySR.flipX)  {
			EnemySR.flipX = true;
			SpawnProjectile.localPosition = new Vector3 (-1, 0, 0);
			SpawnProjectile.localRotation = Quaternion.AngleAxis(180, new Vector3(0.18f,1,0));
		}
	}
}
