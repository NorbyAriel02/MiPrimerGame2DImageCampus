using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDcontroller : MonoBehaviour {
	public Text BulletsText;
	public Text ScoreText;
	public Text TimeText;
	public Slider HealthBar;
	public Image damageImage;
	public bool damaged = false;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	private float time = 0.0f;
	void Update()
	{
		ShowDanger ();
		time += Time.deltaTime;
		SetTime (time);
	}


	public void SetBullets(float bullets)
	{		
		BulletsText.text = "Bullets: " + bullets.ToString ();
	}

	public float GetBullets()
	{
		string[] bullets = BulletsText.text.Split(':');
		return float.Parse(bullets [1]);
	}


	public void SetScore(float value)
	{
		ScoreText.text = "Score: " + value.ToString();
	}

	public float GetScore()
	{
		string[] score = ScoreText.text.Split(':');
		return float.Parse(score [1]);
	}


	public void SetHealth(float value)
	{
		HealthBar.value = value;
	}

	public float GetHealth()
	{
		return HealthBar.value;
	}


	public void SetTime(float time)
	{
		TimeText.text = "Time: " + time.ToString("F2");
	}

	public float GetTime()
	{
		string[] time = TimeText.text.Split(':');
		return float.Parse(time [1]);
	}

	public void ShowDanger()
	{
		if(damaged)
		{
			damageImage.color = flashColour;
		}
		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}
}
