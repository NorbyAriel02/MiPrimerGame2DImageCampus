using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {
	public Button menu;
	public Button Game;


	void Start () {
		menu.onClick.AddListener (GoMenu);
		Game.onClick.AddListener (GoGame);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void GoGame()
	{
		SceneManager.LoadScene ("MenuSeleccionNiveles");
	}

	void GoMenu()
	{
		SceneManager.LoadScene ("MenuPrincipal");
	}
}
