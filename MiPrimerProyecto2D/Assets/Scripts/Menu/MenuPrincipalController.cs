using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPrincipalController : MonoBehaviour {
	public Button play;
	public Button setting;
	public Button credits;
	public Button Exit;

	void Awake()
	{
		play.onClick.AddListener (OnPlay);
		Exit.onClick.AddListener (GoExit);
	}

	public void OnPlay()
	{
		SceneManager.LoadScene ("MenuSeleccionNiveles");
	}

	void GoExit()
	{
		Debug.Log ("Exit");
		Application.Quit ();
	}
}
