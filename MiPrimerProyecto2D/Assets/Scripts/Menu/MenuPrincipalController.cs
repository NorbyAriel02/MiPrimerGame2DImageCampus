using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPrincipalController : MonoBehaviour {
	public Button play;
	public Button Controllers;
	public Button Exit;

	void Awake()
	{
		play.onClick.AddListener (OnPlay);
		Controllers.onClick.AddListener (OnControllers);
		Exit.onClick.AddListener (GoExit);
	}

	public void OnControllers()
	{
		SceneManager.LoadScene ("Controllers");
	}

	public void OnPlay()
	{
		SceneManager.LoadScene ("Nivel1");
	}

	void GoExit()
	{
		Debug.Log ("Exit");
		Application.Quit ();
	}
}
