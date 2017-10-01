using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {
	public Button menu;
	public Button Game;

    private string level;
	void Start () {
        level = PlayerPrefs.GetString("CurrentLevel");
		menu.onClick.AddListener (GoMenu);
		Game.onClick.AddListener (GoGame);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void GoGame()
	{
		SceneManager.LoadScene (level);
	}

	void GoMenu()
	{
		SceneManager.LoadScene ("MenuPrincipal");
	}
}
