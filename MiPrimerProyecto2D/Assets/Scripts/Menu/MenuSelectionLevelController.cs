using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSelectionLevelController : MonoBehaviour {
	public Button BtnLevel01;
	public Button BtnLevel02;
	void Awake () {
		BtnLevel01.onClick.AddListener (ClickBtnLevel01);
		BtnLevel02.onClick.AddListener (ClickBtnLevel02);
	}

	void ClickBtnLevel01()
	{
		SceneManager.LoadScene ("Nivel01");
	}

	void ClickBtnLevel02()
	{
		SceneManager.LoadScene ("MenuPrincipal");
	}

	void Update () {
		
	}
}
