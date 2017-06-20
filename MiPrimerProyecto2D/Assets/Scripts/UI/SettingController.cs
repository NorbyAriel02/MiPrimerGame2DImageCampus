using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingController : MonoBehaviour {
	public Button btnSetMusic;
	public Button btnPruebas;
	public Slider SliderVolume;
	public AudioSource MusicBackGround;
	public AudioSource ASPruebas;
	public AudioClip clip01;
	public AudioClip clip02;
	public AudioClip clip03;
	public AudioClip clip04;

	void Awake()
	{
		btnSetMusic.onClick.AddListener (SetMusic);
		btnPruebas.onClick.AddListener (pruebas);
		SliderVolume.onValueChanged.AddListener (SetVolume);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SetMusic()
	{
		if (MusicBackGround.isPlaying)
			MusicBackGround.Stop ();
		else
			MusicBackGround.Play ();
	}

	void SetVolume(float value)
	{
		MusicBackGround.volume = value;
	}
	void pruebas()
	{
		/*ASPruebas.PlayOneShot (clip01, 1.0f);
		ASPruebas.PlayOneShot (clip02, 1.0f);
		ASPruebas.PlayOneShot (clip03, 1.0f);
		ASPruebas.PlayOneShot (clip04, 1.0f);*/
		ASPruebas.clip = clip04;
		MusicBackGround.clip = clip02;

		ASPruebas.Play ();
		MusicBackGround.PlayDelayed (clip04.length);
		//ASPruebas.clip = clip03;
		//ASPruebas.PlayDelayed (clip02.length);
		//ASPruebas.clip = clip04;
		//ASPruebas.PlayDelayed (clip03.length);
	}
}

