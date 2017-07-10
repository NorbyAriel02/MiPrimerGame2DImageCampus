using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimController : MonoBehaviour {
	public Animator anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool IsWalk()
	{
		return anim.GetBool ("IsWalk");
	}

	public void SetWalk()
	{
		anim.SetBool("IsAttack", false);
		anim.SetBool("IsWalk", true);
	}

	public void SetAttack()
	{
		anim.SetBool("IsAttack", true);
	}

	public void SetIdle()
	{
		anim.SetBool("IsWalk", false);
		anim.SetBool("IsAttack", false);
	}

	public void SetDie()
	{
		anim.SetBool("IsWalk", false);
		anim.SetBool("IsAttack", false);
		anim.SetBool("IsDie", true);
	}

	public void SetHit()
	{
		anim.SetTrigger ("IsHit");
	}
}
