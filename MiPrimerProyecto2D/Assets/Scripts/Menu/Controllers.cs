using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Controllers : MonoBehaviour {
	public Button Exit;

	void Awake()
	{
		Exit.onClick.AddListener (GoMenu);
	}

	public void GoMenu()
	{
		SceneManager.LoadScene ("MenuPrincipal");
	}
}
