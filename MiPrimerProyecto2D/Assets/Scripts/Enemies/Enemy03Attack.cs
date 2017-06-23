using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy03Attack : MonoBehaviour 
{
	//private variable
	private Animator Anim;
	private EnemyHealth Defending;
	void Awake()
	{
		Anim = GetComponent<Animator>();
		Defending = GetComponent<EnemyHealth>();
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
		Debug.Log ("area de ataque");
		if(other.gameObject.tag == "Player")
		{
			EnemyIsAttacking ();
		}
	}
}
